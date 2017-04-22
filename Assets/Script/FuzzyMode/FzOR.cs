using System;
using System.Collections.Generic;

namespace Zkull.Fuzzy
{
	public class FzOR : FuzzyTerm
	{
		private List<FuzzyTerm> m_lstTerms;

		public FzOR(FzOR self)
		{
			m_lstTerms = new List<FuzzyTerm>();
			for(int i = 0; i < self.m_lstTerms.Count; i++)
			{
				m_lstTerms.Add(self.m_lstTerms[i]);
			}
		}
		public FzOR (params FuzzyTerm[] fzTerm)
		{
			m_lstTerms = new List<FuzzyTerm>();
			for(int i = 0; i < fzTerm.Length; i++)
			{
				m_lstTerms.Add(fzTerm[i]);
			}
		}

		public override FuzzyTerm Clone ()
		{
			return new FzAND(this);
		}

		public override float GetDOM ()
		{
			float largest = float.MinValue;
			for(int i = 0; i < m_lstTerms.Count; i++)
			{
				FuzzyTerm term = m_lstTerms[i];
				if(term.GetDOM() > largest)
				{
					largest = term.GetDOM();
				}
			}
			return largest;
		}

		public override void ORwithDOM (float val)
		{
			for(int i = 0; i < m_lstTerms.Count; i++)
			{
				FuzzyTerm term = m_lstTerms[i];
				term.ORwithDOM(val);
			}
		}

		public override void ClearDOM ()
		{
			for(int i = 0; i < m_lstTerms.Count; i++)
			{
				FuzzyTerm term = m_lstTerms[i];
				term.ClearDOM();
			}
		}
	}
}

