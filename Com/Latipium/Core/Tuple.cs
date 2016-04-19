// DataObject.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;

namespace Com.Latipium.Core {
	/// <summary>
	/// A data object for two variables.
	/// </summary>
	public class Tuple<T1, T2> {
		/// <summary>
		/// The 1st object.
		/// </summary>
		public T1 Object1;

		/// <summary>
		/// The 2nd object.
		/// </summary>
		public T2 Object2;

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="Com.Latipium.Core.Tuple{T1,T2}"/>.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="Com.Latipium.Core.Tuple{T1,T2}"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="Com.Latipium.Core.Tuple{T1,T2}"/>; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) {
			if ( obj is Tuple<T1, T2> ) {
				Tuple<T1, T2> t = (Tuple<T1, T2>) obj;
				return t.Object1.Equals(Object1) && t.Object2.Equals(Object2);
			}
			return false;
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="Com.Latipium.Core.Tuple{T1,T2}"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode() {
			return Object1.GetHashCode() ^ Object2.GetHashCode();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Com.Latipium.Core.Tuple{T1,T2}"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Com.Latipium.Core.Tuple{T1,T2}"/>.</returns>
		public override string ToString() {
			return string.Format("({0}, {1})", Object1, Object2);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Core.Tuple{T1,T2}"/> class.
		/// </summary>
		public Tuple() {
			Object1 = default(T1);
			Object2 = default(T2);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Core.Tuple{T1,T2}"/> class.
		/// </summary>
		/// <param name="o1">The 1st object.</param>
		/// <param name="o2">The 2nd object.</param>
		public Tuple(T1 o1, T2 o2) {
			Object1 = o1;
			Object2 = o2;
		}
	}

	/// <summary>
	/// A data object for three variables.
	/// </summary>
	public class Tuple<T1, T2, T3> {
		/// <summary>
		/// The 1st object.
		/// </summary>
		public T1 Object1;

		/// <summary>
		/// The 2nd object.
		/// </summary>
		public T2 Object2;

		/// <summary>
		/// The 3rd object.
		/// </summary>
		public T3 Object3;

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="Com.Latipium.Core.Tuple{T1,T2,T3}"/>.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="Com.Latipium.Core.Tuple{T1,T2,T3}"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="Com.Latipium.Core.Tuple{T1,T2,T3}"/>; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) {
			if ( obj is Tuple<T1, T2, T3> ) {
				Tuple<T1, T2, T3> t = (Tuple<T1, T2, T3>) obj;
				return t.Object1.Equals(Object1) && t.Object2.Equals(Object2) && t.Object3.Equals(Object3);
			}
			return false;
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="Com.Latipium.Core.Tuple{T1,T2,T3}"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode() {
			return Object1.GetHashCode() ^ Object2.GetHashCode() ^ Object3.GetHashCode();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Com.Latipium.Core.Tuple{T1,T2,T3}"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Com.Latipium.Core.Tuple{T1,T2,T3}"/>.</returns>
		public override string ToString() {
			return string.Format("({0}, {1}, {2})", Object1, Object2, Object3);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Core.Tuple{T1,T2,T3}"/> class.
		/// </summary>
		public Tuple() {
			Object1 = default(T1);
			Object2 = default(T2);
			Object3 = default(T3);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Core.Tuple{T1,T2,T3}"/> class.
		/// </summary>
		/// <param name="o1">The 1st object.</param>
		/// <param name="o2">The 2nd object.</param>
		/// <param name="o3">The 3rd object.</param>
		public Tuple(T1 o1, T2 o2, T3 o3) {
			Object1 = o1;
			Object2 = o2;
			Object3 = o3;
		}
	}

	/// <summary>
	/// A data object for four variables.
	/// </summary>
	public class Tuple<T1, T2, T3, T4> {
		/// <summary>
		/// The 1st object.
		/// </summary>
		public T1 Object1;

		/// <summary>
		/// The 2nd object.
		/// </summary>
		public T2 Object2;

		/// <summary>
		/// The 3rd object.
		/// </summary>
		public T3 Object3;

		/// <summary>
		/// The 4th object.
		/// </summary>
		public T4 Object4;

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="Com.Latipium.Core.Tuple{T1,T2,T3,T4}"/>.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="Com.Latipium.Core.Tuple{T1,T2,T3,T4}"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="Com.Latipium.Core.Tuple{T1,T2,T3,T4}"/>; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) {
			if ( obj is Tuple<T1, T2, T3, T4> ) {
				Tuple<T1, T2, T3, T4> t = (Tuple<T1, T2, T3, T4>) obj;
				return t.Object1.Equals(Object1) && t.Object2.Equals(Object2) && t.Object3.Equals(Object3) && t.Object4.Equals(Object4);
			}
			return false;
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="Com.Latipium.Core.Tuple{T1,T2,T3,T4}"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode() {
			return Object1.GetHashCode() ^ Object2.GetHashCode() ^ Object3.GetHashCode() ^ Object4.GetHashCode();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Com.Latipium.Core.Tuple{T1,T2,T3,T4}"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Com.Latipium.Core.Tuple{T1,T2,T3,T4}"/>.</returns>
		public override string ToString() {
			return string.Format("({0}, {1}, {2}, {3})", Object1, Object2, Object3, Object4);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Core.Tuple{T1,T2,T3,T4}"/> class.
		/// </summary>
		public Tuple() {
			Object1 = default(T1);
			Object2 = default(T2);
			Object3 = default(T3);
			Object4 = default(T4);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Core.Tuple{T1,T2,T3,T4}"/> class.
		/// </summary>
		/// <param name="o1">The 1st object.</param>
		/// <param name="o2">The 2nd object.</param>
		/// <param name="o3">The 3rd object.</param>
		/// <param name="o4">The 4th object.</param>
		public Tuple(T1 o1, T2 o2, T3 o3, T4 o4) {
			Object1 = o1;
			Object2 = o2;
			Object3 = o3;
			Object4 = o4;
		}
	}
}

