#if UNITY_64
using UnityEngine;
#endif

namespace FixedpointMath
{
	public struct Vector3FixedPoint
	{
		public FixedPoint X;
		public FixedPoint Y;
		public FixedPoint Z;

		public FixedPoint SqrMagnitude
		{
			get { return X * X + Y * Y + Z * Z; }
		}

		public FixedPoint Magnitude
		{
			get { return MathFunctions.Sqrt(SqrMagnitude); }
		}

		public Vector3FixedPoint Normalized
		{
			get
			{
				FixedPoint mag = Magnitude;

				return mag == 0 ? new Vector3FixedPoint(0, 0, 0) : this / mag;
			}
		}

		public static Vector3FixedPoint Zero = new Vector3FixedPoint();
		public static Vector3FixedPoint One = new Vector3FixedPoint(1, 1, 1);
		public static Vector3FixedPoint Right = new Vector3FixedPoint(1, 0, 0);
		public static Vector3FixedPoint Up = new Vector3FixedPoint(0, 1, 0);
		public static Vector3FixedPoint Forward = new Vector3FixedPoint(0, 0, 1);

#if !UNITY_64
		public Vector3FixedPoint()
		{
		}
#endif

		public Vector3FixedPoint(FixedPoint x, FixedPoint y, FixedPoint z)
		{
			X = x;
			Y = y;
			Z = z;
		}

#if UNITY_64
		public Vector3FixedPoint(Vector3 value)
		{
			X = value.x;
			Y = value.y;
			Z = value.z;
		}
#endif

		public void Normalize()
		{
			FixedPoint mag = Magnitude;

			this /= mag;
		}

		public override bool Equals(object? obj)
		{
			if (obj is Vector3FixedPoint other)
			{
				return this == other;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode() << 2 ^ Z.GetHashCode() >> 2;
		}

		public override string ToString()
		{
			return $"({X}, {Y}, {Z})";
		}

		public static Vector3FixedPoint operator +(Vector3FixedPoint a, Vector3FixedPoint b)
		{
			return new Vector3FixedPoint(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		public static Vector3FixedPoint operator -(Vector3FixedPoint a, Vector3FixedPoint b)
		{
			return new Vector3FixedPoint(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}

		public static Vector3FixedPoint operator *(Vector3FixedPoint a, FixedPoint scalar)
		{
			return new Vector3FixedPoint(a.X * scalar, a.Y * scalar, a.Z * scalar);
		}

		public static Vector3FixedPoint operator /(Vector3FixedPoint a, FixedPoint scalar)
		{
			return new Vector3FixedPoint(a.X / scalar, a.Y / scalar, a.Z / scalar);
		}

		public static bool operator ==(Vector3FixedPoint a, Vector3FixedPoint b)
		{
			return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
		}

		public static bool operator !=(Vector3FixedPoint a, Vector3FixedPoint b)
		{
			return !(a == b);
		}

#if UNITY_64
		public static implicit operator Vector3(Vector3FixedPoint value)
		{
			return new Vector3(value.X, value.Y, value.Z);
		}

		public static implicit operator Vector3FixedPoint(Vector3 value)
		{
			return new Vector3FixedPoint(value);
		}
#endif
	}
}