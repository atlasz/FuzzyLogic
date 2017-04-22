using System;
using System.Collections.Generic;

namespace Zkull.Fuzzy
{
	public class FzAND : FuzzyTerm
	{
		private List<FuzzyTerm> m_lstTerms;

		public FzAND(FzAND self)
		{
			m_lstTerms = new List<FuzzyTerm>();
			for(int i = 0; i < self.m_lstTerms.Count; i++)
			{
				m_lstTerms.Add(self.m_lstTerms[i]);
			}
		}
		public FzAND (params FuzzyTerm[] fzTerm)
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
			float smallest = float.MaxValue;
			for(int i = 0; i < m_lstTerms.Count; i++)
			{
				FuzzyTerm term = m_lstTerms[i];
				if(term.GetDOM() < smallest)
				{
					smallest = term.GetDOM();
				}
			}
			return smallest;
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

