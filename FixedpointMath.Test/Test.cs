#if !UNITY_64
[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace FixedpointMath.Test
{
	[TestClass]
	public sealed class Test
	{
		[TestMethod]
		public void TestRoutine()
		{
			FixedPoint fp = new FixedPoint(1);
			Assert.IsTrue(fp == 1);

			fp = 1.5;
			Assert.IsTrue(fp == 1.5F);

			fp = new FixedPoint(2.0F);
			Assert.IsTrue(fp == 2.0);

			Assert.IsTrue(fp + 3 == 5);
			Assert.IsTrue(fp - 3 == -1);
			Assert.IsTrue(fp * 2 == 4);
			Assert.IsTrue(fp / 2 == 1);

			fp = 3;
			Assert.IsTrue(fp % 2 == 1);

			Assert.IsTrue(FixedPoint.Sqrt((FixedPoint)4) == 2);

			Vector3FixedPoint vector = Vector3FixedPoint.One;
			Assert.IsTrue(vector.Normalized == Vector3FixedPoint.One * 0.5773468);

			vector.Normalize();
			Assert.IsTrue(vector.Normalized == Vector3FixedPoint.One * 0.5773468);

			vector = Vector3FixedPoint.Right;
			Assert.IsTrue(vector.SqrMagnitude == 1);

			Assert.IsTrue(Vector3FixedPoint.One.Magnitude * Vector3FixedPoint.One.Magnitude <= Vector3FixedPoint.One.SqrMagnitude);

			Assert.IsTrue(vector + Vector3FixedPoint.Up == new Vector3FixedPoint(1, 1, 0));
			Assert.IsTrue(vector - Vector3FixedPoint.Up == new Vector3FixedPoint(1, -1, 0));
			Assert.IsTrue(vector * 2 == new Vector3FixedPoint(2, 0, 0));
			Assert.IsTrue(vector / 2 == new Vector3FixedPoint(0.5, 0, 0));

			for (int i = 32768; i < 1000000; ++i)
			{
				Assert.IsTrue((FixedPoint)i == i);
			}
		}
	}
}
#endif