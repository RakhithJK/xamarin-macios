//
// Authors:
//     Stephane Delcroix <sephane@delcroix.org>
//
// Copyright (c) 2021 Microsoft Inc
//

//
// This represents the native vector_float2 type, which is 8 bytes.
//

using System;
using System.Runtime.InteropServices;

#if NET
namespace CoreGraphics
{
	[StructLayout (LayoutKind.Sequential)]
	public struct NVector2 : IEquatable<NVector2>
	{
		public float X;
		public float Y;

		public NVector2 (float x, float y)
		{
			X = x;
			Y = y;
		}

		public static bool operator == (NVector2 left, NVector2 right) =>
			left.Equals (right);

		public static bool operator != (NVector2 left, NVector2 right) =>
			!left.Equals (right);

		public override string ToString () =>
			$"({X}, {Y})";

		public override int GetHashCode () =>
			X.GetHashCode () ^ Y.GetHashCode ();

		public override bool Equals (object obj)
		{
			if (!(obj is NVector2))
				return false;

			return Equals ((NVector2) obj);
		}

		public bool Equals (NVector2 other) =>
			X == other.X && Y == other.Y;
	}
}
#endif // NET
