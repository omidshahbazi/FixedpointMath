using System.Diagnostics;

namespace FixedpointMath
{
	public struct FixedPoint
	{
		private const int FractionalBits = 16;

		private long m_RawValue;

		public FixedPoint(double value) :
			this((float)value)
		{
		}

		public FixedPoint(int value) :
			this((float)value)
		{
		}

		public FixedPoint(float value)
		{
			m_RawValue = (long)(value * (1 << FractionalBits));
		}

		public override bool Equals(object? obj)
		{
			if (obj is FixedPoint other)
			{
				return this == other;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return (int)(m_RawValue << 2);
		}

		public override string ToString()
		{
			return $"{(float)this}FP";
		}

		public static FixedPoint operator +(FixedPoint a, FixedPoint b)
		{
			FixedPoint result;
			result.m_RawValue = a.m_RawValue + b.m_RawValue;

			return result;
		}

		public static FixedPoint operator -(FixedPoint a, FixedPoint b)
		{
			FixedPoint result;
			result.m_RawValue = a.m_RawValue - b.m_RawValue;

			return result;
		}

		public static FixedPoint operator *(FixedPoint a, FixedPoint b)
		{
			FixedPoint result;
			result.m_RawValue = (a.m_RawValue * b.m_RawValue) >> FractionalBits;

			return result;
		}

		public static FixedPoint operator /(FixedPoint a, FixedPoint b)
		{
			FixedPoint result;
			result.m_RawValue =(a.m_RawValue << FractionalBits) / b.m_RawValue;

			return result;
		}

		public static FixedPoint operator %(FixedPoint a, FixedPoint b)
		{
			FixedPoint result;
			result.m_RawValue = a.m_RawValue % b.m_RawValue;

			return result;
		}

		public static implicit operator int(FixedPoint value)
		{
			return (int)(float)value;
		}

		public static implicit operator float(FixedPoint value)
		{
			return (float)value.m_RawValue / (1 << FractionalBits);
		}

		public static implicit operator FixedPoint(int value)
		{
			return new FixedPoint(value);
		}

		public static implicit operator FixedPoint(float value)
		{
			return new FixedPoint(value);
		}

		public static implicit operator FixedPoint(double value)
		{
			return new FixedPoint(value);
		}

		public static FixedPoint Sqrt(FixedPoint value)
		{
			Debug.Assert(value >= 0);

			if (value.m_RawValue == 0)
				return 0;

			long x = value.m_RawValue << FractionalBits;
			long rawResult = 0;
			long bit = 1L << (32 + FractionalBits);

			while (bit > x)
				bit >>= 2;

			while (bit != 0)
			{
				if (x >= rawResult + bit)
				{
					x -= rawResult + bit;
					rawResult = (rawResult >> 1) + bit;
				}
				else
				{
					rawResult >>= 1;
				}
				bit >>= 2;
			}

			FixedPoint result;
			result.m_RawValue = (int)rawResult;
			return result;
		}

		public static FixedPoint Floor(FixedPoint value)
		{
			FixedPoint result;
			result.m_RawValue = value.m_RawValue & ~FractionalBits;

			return result;
		}
	}
}