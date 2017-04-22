using System;

namespace Zkull.Fuzzy
{
	public class FzSet : FuzzyTerm
	{
		private FuzzySet m_set;
		public FuzzySet myset
		{
			get
			{
				return m_set;
			}
		}

		public FzSet (FuzzySet fs)
		{
			m_set = fs;
		}

		public override FuzzyTerm Clone()
		{
			return new FzSet(m_set);
		}

		public override float GetDOM()
		{
			return  m_set.GetDOM();
		}

		public override void ORwithDOM(float val)
		{
			m_set.ORwithDOM(val);
		}
			
		public override void ClearDOM()
		{
			m_set.ClearDOM();
		}



	}
}

