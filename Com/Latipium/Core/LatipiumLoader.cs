// LatipiumLoader.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;

namespace Com.Latipium.Core {
	/// <summary>
	/// Some code that loads when Latipium starts.
	/// </summary>
	public interface LatipiumLoader : LatipiumObject {
		/// <summary>
		/// Loads this instance.
		/// </summary>
		void Load();
	}
}

