using System;

namespace Zkull.Fuzzy
{
	public class FzFairly : FuzzyTerm
	{
		private FuzzySet m_set;

		public FzFairly(FzFairly self)
		{
			m_set = self.m_set;
		}

		public FzFairly (FzSet fs)
		{
			m_set = fs.myset;
		}

		public override FuzzyTerm Clone ()
		{
			return new FzFairly(this);
		}

		public override float GetDOM ()
		{
			return UnityEngine.Mathf.Sqrt( m_set.GetDOM());
		}

		public override void ClearDOM ()
		{
			m_set.ClearDOM();
		}

		public override void ORwithDOM (float val)
		{
			m_set.ORwithDOM( UnityEngine.Mathf.Sqrt(val));
		}
	}
}

