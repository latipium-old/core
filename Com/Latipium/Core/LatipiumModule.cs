// LatipiumModule.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;

namespace Com.Latipium.Core {
	/// <summary>
	/// A module that provides a core functionality to Latipium.
	/// </summary>
	public interface LatipiumModule : LatipiumObject {
		/// <summary>
		/// Gets the provided types.
		/// </summary>
		/// <value>A list of every module type this class provides.</value>
		string[] Provides {
			get;
		}

		/// <summary>
		/// Gets the priorities of the provided types.
		/// </summary>
		/// <value>A list of the priorities for each provided core functionality.</value>
		int[] Priorities {
			get;
		}

		/// <summary>
		/// Load this implementation of the module.
		/// </summary>
		/// <param name="name">The name of the type of core functionality to load.</param>
		void Load(string name);
	}
}

