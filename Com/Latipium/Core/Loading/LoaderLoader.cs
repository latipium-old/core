// LoaderLoader.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Linq;
using System.Reflection;

namespace Com.Latipium.Core.Loading {
	internal static class LoaderLoader {
		private static readonly Type ModuleType = typeof(LatipiumModule);
		private static readonly Type LoaderType = typeof(LatipiumLoader);
		private static readonly Assembly ThisAssembly = Assembly.GetAssembly(LoaderType);

		internal static void LoadLoaderModules() {
			foreach ( LatipiumModule mod in ModuleLoader.GetModules() ) {
				if ( mod is LatipiumLoader ) {
					((LatipiumLoader) mod).Load();
				}
			}
		}

		internal static void LoadAssembly(Assembly assembly) {
			if ( assembly != ThisAssembly ) {
				foreach ( LatipiumLoader loader in assembly.GetExportedTypes()
					.Where((Type type) => 
						LoaderType.IsAssignableFrom(type) &&
						!ModuleType.IsAssignableFrom(type))
					.Select((Type type) => (LatipiumLoader) 
						type.GetConstructor(new Type[0])
						.Invoke(new object[0])) ) {
					loader.Load();
				}
			}
		}
	}
}

