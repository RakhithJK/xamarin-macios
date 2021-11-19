//
// QuaternionDouble.cs:
//     This represents the native quaternion double type, which is  16 bytes.
//
//
// Authors:
//     Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2021 Microsoft Inc
//

using System;
using System.Runtime.InteropServices;

#if NET
namespace CoreGraphics
{
	[StructLayout (LayoutKind.Sequential)]
	public struct NQuaternion : IEquatable<NQuaternion>
	{
		float x;
		float y;
		float z;
		float w;

		public NQuaternion (float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public NVector3 Xyz
		{
		    get => new NVector3(x, y, z);
		    set
		    {
			x = value.X;
			y = value.Y;
			z = value.Z;       
		    }
		}

		public float X
		{
		    get => x;
		    set => x = value;
		}

		public float Y
		{
		    get => y;
		    set => y = value;
		}

		public float Z
		{
		    get => z;
		    set => z = value;
		}

		public float W
		{
		    get => w;
		    set => w = value;
		}

		public static bool operator == (NQuaternion left, NQuaternion right)
		{
			return left.Equals (right);
		}

		public static bool operator != (NQuaternion left, NQuaternion right)
		{
			return !left.Equals (right);
		}

		public override string ToString ()
		{
			return $"({X}, {Y}, {Z}, {W})";
		}

		public override int GetHashCode ()
		{
			return X.GetHashCode () ^ Y.GetHashCode () ^ Z.GetHashCode () ^ W.GetHashCode ();
		}

		public override bool Equals (object obj)
		{
			if (!(obj is NQuaternion))
				return false;

			return Equals ((NQuaternion) obj);
		}

		public bool Equals (NQuaternion other)
		{
			return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
		}
	}
}
#endif // NET
