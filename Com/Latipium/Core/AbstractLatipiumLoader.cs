// AbstractLatipiumLoader.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;

namespace Com.Latipium.Core {
	/// <summary>
	/// Simple implementation of a LatipiumLoader.
	/// </summary>
	public abstract class AbstractLatipiumLoader : AbstractLatipiumObject, LatipiumLoader {
		/// <summary>
		/// Loads this instance.
		/// </summary>
		public abstract void Load();
	}
}

