// ModuleLoader.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Com.Latipium.Core.Loading {
	internal static class ModuleLoader {
		private static readonly List<LatipiumModule> Modules = new List<LatipiumModule>();
		private static readonly Type ModuleType = typeof(LatipiumModule);
		private static readonly Assembly ThisAssembly = Assembly.GetAssembly(ModuleType);

		internal static void RegisterAssembly(Assembly assembly) {
			if ( assembly != ThisAssembly ) {
				Modules.AddRange(
					assembly.GetExportedTypes()
					.Where((Type type) => 
						ModuleType.IsAssignableFrom(type))
					.Select((Type type) => (LatipiumModule) 
						type.GetConstructor(new Type[0])
						.Invoke(new object[0])));
			}
		}

		internal static IEnumerable<LatipiumModule> GetModules() {
			return Modules;
		}
	}
}

