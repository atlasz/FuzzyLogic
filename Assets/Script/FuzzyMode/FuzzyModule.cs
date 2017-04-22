using System;
using System.Collections.Generic;

namespace Zkull.Fuzzy
{
	public enum DefuzzifyMethod
	{
		MAX_AV = 0,
		CENTROID = 1,
	}

	public class FuzzyModule
	{
		private Dictionary<string, FuzzyVariable> m_dicFuzzyVarialbe = new Dictionary<string, FuzzyVariable>();

		private List<FuzzyRule> m_lstRules = new List<FuzzyRule>();

		private int m_sample = 15;

		public void SetSample(int val)
		{
			m_sample = val;
		}

		public FuzzyVariable CreateFLV(string name)
		{
			m_dicFuzzyVarialbe[name] = new FuzzyVariable();
			return m_dicFuzzyVarialbe[name];
		}

		public void AddRule(FuzzyTerm antecedent, FuzzyTerm consequence)
		{
			m_lstRules.Add(new FuzzyRule(antecedent, consequence));
		}

		public void Fuzzify(string name , float val)
		{
			FuzzyVariable fuzzyVal = null;
			if(m_dicFuzzyVarialbe.TryGetValue(name, out fuzzyVal))
			{
				m_dicFuzzyVarialbe[name].Fuzzify(val);
			}
		}

		private void SetConfidencesOfConsequentsToZero()
		{
			for(int i = 0; i < m_lstRules.Count; i++)
			{
				m_lstRules[i].SetConfidenceOfConsequentToZero();
			}
		}

		public float Defuzzify(string name, DefuzzifyMethod method)
		{
			FuzzyVariable fuzzyVal = null;
			if(m_dicFuzzyVarialbe.TryGetValue(name, out fuzzyVal))
			{
				for(int i = 0 ; i < m_lstRules.Count; i++)
				{
					float value = m_lstRules[i].Calculate();
					UnityEngine.Debug.Log("rule " + i + " " + value);
				}
				switch(method)
				{
				case DefuzzifyMethod.CENTROID:
					return m_dicFuzzyVarialbe[name].DeFuzzifyCentroid(m_sample);
				case DefuzzifyMethod.MAX_AV:
					return m_dicFuzzyVarialbe[name].DeFuzzifyMaxAv();
				}
			}

			return 0;
		}
	}
}

