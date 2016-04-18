// LatipiumMethod.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;

namespace Com.Latipium.Core {
	/// <summary>
	/// Attribute for a method that can be called on a LatipiumObject.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Event)]
	public class LatipiumMethod : Attribute {
		/// <summary>
		/// The name of the method.
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Core.LatipiumMethod"/> class.
		/// </summary>
		/// <param name="name">The name of the method.</param>
		public LatipiumMethod(string name) {
			Name = name;
		}
	}
}

