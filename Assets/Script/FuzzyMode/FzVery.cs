using System;

namespace Zkull.Fuzzy
{
	public class FzVery : FuzzyTerm
	{
		private FuzzySet m_set;

		public FzVery(FzVery self)
		{
			m_set = self.m_set;
		}

		public FzVery (FzSet fs)
		{
			m_set = fs.myset;
		}

		public override FuzzyTerm Clone ()
		{
			return new FzVery(this);
		}

		public override float GetDOM ()
		{
			return m_set.GetDOM() * m_set.GetDOM();
		}

		public override void ClearDOM ()
		{
			m_set.ClearDOM();
		}

		public override void ORwithDOM (float val)
		{
			m_set.ORwithDOM(val);
		}
	}
}

