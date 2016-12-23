// AssemblyLoader.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using log4net;

namespace Com.Latipium.Core.Loading {
	/// <summary>
	/// Loads assemblies into Latipium.
	/// </summary>
	public static class AssemblyLoader {
		private static readonly ILog Log = LogManager.GetLogger(typeof(AssemblyLoader));
        private static readonly Dictionary<string, Assembly> Assemblies = new Dictionary<string, Assembly>();

        private static Assembly ResolveDependency(object sender, ResolveEventArgs args) {
            return Assemblies[args.Name.Split(',')[0]];
        }

		/// <summary>
		/// Initializes the loader and loads all assemblies.
		/// </summary>
		/// <param name="io">The assembly containing the io module</param>
		public static void Init(Assembly io) {
			List<Assembly> assemblies = new List<Assembly>();
			// Register the IO assembly first so we can use it
			ModuleLoader.RegisterAssembly(io);
			assemblies.Add(io);
            Assemblies[io.GetName().Name] = io;
			LatipiumModule mod = ModuleFactory.FindModule("Com.Latipium.Modules.IO");
            if ( mod != null ) {
                Func<string, FileMode, FileAccess, Stream> Open = mod.GetFunction<string, FileMode, FileAccess, Stream>("Open");
                if ( Open != null ) {
                    // Pull the list of mods from the IO assembly
                    foreach ( string file in mod.InvokeFunction<IEnumerable<string>>("GetModules") ) {
                        try {
                            Stream stream = Open(file, FileMode.Open, FileAccess.Read);
                            if ( stream == null ) {
                                Log.ErrorFormat("IO module was unable to open file {0}", file);
                            } else {
                                byte[] buffer = new byte[stream.Length];
                                stream.Read(buffer, 0, buffer.Length);
                                stream.Close();
                                stream.Dispose();
                                Assembly asm = Assembly.Load(buffer);
                                assemblies.Add(asm);
                                Assemblies[asm.GetName().Name] = asm;
                            }
                        } catch ( Exception ex ) {
                            Log.Error(ex);
                        }
                    }
                }
            }
            AppDomain.CurrentDomain.AssemblyResolve += ResolveDependency;
            foreach (Assembly asm in assemblies) {
                ModuleLoader.RegisterAssembly(asm);
            }
			LoaderLoader.LoadLoaderModules();
			foreach ( Assembly asm in assemblies ) {
				LoaderLoader.LoadAssembly(asm);
			}
		}
	}
}

