using System.Diagnostics;

namespace FixedpointMath
{
	public class ScopeTimer
	{
		private string m_Name;
		private Stopwatch m_StopWatch = null;

		public ScopeTimer(string name = null)
		{
			m_Name = name;
			m_StopWatch = Stopwatch.StartNew();
		}

		public void Reset()
		{
			m_StopWatch.Restart();
		}

		public long Measure(long expected = 0)
		{
			long elapsed = m_StopWatch.ElapsedMilliseconds;

			if (expected != 0)
				Debug.Assert(elapsed <= expected, m_Name);

			return elapsed;
		}
	}
}