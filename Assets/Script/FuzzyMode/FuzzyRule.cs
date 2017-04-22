using System;

namespace Zkull.Fuzzy
{
	public class FuzzyRule
	{
		private FuzzyTerm m_antecedent;
		private FuzzyTerm m_consequence;

		public FuzzyRule (FuzzyTerm ant, FuzzyTerm cons)
		{
			m_antecedent = ant.Clone();
			m_consequence = cons.Clone();
		}

		public void SetConfidenceOfConsequentToZero()
		{
			m_consequence.ClearDOM();
		}

		public float Calculate()
		{
			m_consequence.ORwithDOM(m_antecedent.GetDOM());
			return m_antecedent.GetDOM();
		}
	}
}

