// AbstractLatipiumModule.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;

namespace Com.Latipium.Core {
	/// <summary>
	/// Simple implementation of a LatipiumModule.
	/// </summary>
	public abstract class AbstractLatipiumModule : AbstractLatipiumObject, LatipiumModule {
		private readonly string[] _Provides;
		private readonly int[] _Priorities;

		/// <summary>
		/// Gets the provided types.
		/// </summary>
		/// <value>A list of every module type this class provides.</value>
		public string[] Provides {
			get {
				return _Provides;
			}
		}

		/// <summary>
		/// Gets the priorities of the provided types.
		/// </summary>
		/// <value>A list of the priorities for each provided core functionality.</value>
		public int[] Priorities {
			get {
				return _Priorities;
			}
		}

		/// <summary>
		/// Load this implementation of the module.
		/// </summary>
		/// <param name="name">The name of the type of core functionality to load.</param>
		public virtual void Load(string name) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Core.AbstractLatipiumModule"/> class.
		/// </summary>
		/// <param name="provides">A list of every module type this class provides.</param>
		/// <param name="priorities">A list of the priorities for each provided core functionality.</param>
		protected AbstractLatipiumModule(string[] provides, int[] priorities = null) {
			_Provides = provides;
			_Priorities = new int[_Provides.Length];
			int i = 0;
			if ( priorities != null ) {
				for ( ; i < _Provides.Length &&
					i < priorities.Length; ++i ) {
					_Priorities[i] = priorities[i];
				}
			}
			// Fill the rest of the priorities with zeros
			for ( ; i < _Provides.Length; ++i ) {
				_Priorities[i] = 0;
			}
		}
	}
}

