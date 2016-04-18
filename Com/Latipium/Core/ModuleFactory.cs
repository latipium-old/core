// ModuleFactory.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Collections;
using System.Collections.Generic;
using Com.Latipium.Core.Loading;

namespace Com.Latipium.Core {
	/// <summary>
	/// Creates Latipium modules.
	/// </summary>
	public static class ModuleFactory {
		private static readonly Dictionary<string, LatipiumModule> LoadedModules = new Dictionary<string, LatipiumModule>();

		private static LatipiumModule GetModule(string type) {
			LatipiumModule mod = null;
			int priority = int.MinValue;
			foreach ( LatipiumModule impl in ModuleLoader.GetModules() ) {
				for ( int i = 0; i < impl.Provides
					.Length; ++i ) {
					if ( impl.Provides[i] == type ) {
						if ( impl.Priorities[i] > priority ) {
							mod = impl;
							priority = impl.Priorities[i];
						}
						break;
					}
				}
			}
			if ( mod != null ) {
				mod.Load(type);
			}
			return mod;
		}

		/// <summary>
		/// Finds a module by its type.
		/// </summary>
		/// <returns>The found module, or null if nothing implements that module.</returns>
		/// <param name="type">The type of module to find.</param>
		public static LatipiumModule FindModule(string type) {
			if ( LoadedModules.ContainsKey(type) ) {
				return LoadedModules[type];
			} else {
				return LoadedModules[type] = GetModule(type);
			}
		}
	}
}

