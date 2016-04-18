// MethodDescriptor.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;

namespace Com.Latipium.Core.Data {
	internal struct MemberDescriptor : IComparable<MemberDescriptor> {
		internal Type Type;
		internal string Name;

		public override bool Equals(object obj) {
			if ( obj is MemberDescriptor ) {
				MemberDescriptor desc = (MemberDescriptor) obj;
				return Type == desc.Type &&
					Name == desc.Name;
			} else {
				return false;
			}
		}

		public int CompareTo(MemberDescriptor other) {
			int diff = Name.CompareTo(
				other.Name);
			if ( diff != 0 ) {
				return diff;
			}
			return Type.GetHashCode()
				.CompareTo(
					other.GetHashCode());
		}

		public override int GetHashCode() {
			return Type.GetHashCode() ^
				Name.GetHashCode();
		}
	}
}

