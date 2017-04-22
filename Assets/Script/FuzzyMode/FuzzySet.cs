using System;

namespace Zkull.Fuzzy
{
	public class FuzzySet
	{
		protected float m_dom;
		protected float m_representativeValue;

		public FuzzySet()
		{
			
		}

		public FuzzySet (float DOM, float representative)
		{
			m_dom = DOM;
			m_representativeValue = representative;
		}

		public virtual float CalculateDOM(float val)
		{
			return 0;
		}

		public void ORwithDOM(float val)
		{
			m_dom = val > m_dom ? val : m_dom;
		}

		public float GetRepresentativeVal()
		{
			return m_representativeValue;
		}

		public void ClearDOM()
		{
			m_dom = 0;
		}

		public void SetDOM(float val)
		{
			m_dom = val;
		}

		public float GetDOM()
		{
			return m_dom;
		}
	}
}

