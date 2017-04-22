using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zkull.Fuzzy
{
	public class FuzzyVariable
	{
		private Dictionary<string, FuzzySet> m_dicFuzzyVariable = new Dictionary<string, FuzzySet>();
		private float m_minRange;
		private float m_maxRange;

		public FuzzyVariable()
		{
		}

		public FuzzyVariable (float min, float max)
		{
			m_maxRange = max;
			m_minRange = min;
		}

		public void AdjustRangeToFit(float min, float max)
		{
			if(min < m_minRange)
			{
				m_minRange = min;
			}
			if(max > m_maxRange)
			{
				m_maxRange = max;
			}
		}

		public void AddFuzzySet(string name, FuzzySet fuzzySet)
		{
			m_dicFuzzyVariable[name] = fuzzySet;
		}

		public void Fuzzify(float val)
		{
			foreach(KeyValuePair<string, FuzzySet> fuzzySet in m_dicFuzzyVariable)
			{
				float value = fuzzySet.Value.CalculateDOM(val);
				Debug.Log(fuzzySet.Key + "  val: " + val + "  DOM:" + value);
				fuzzySet.Value.SetDOM(value);
			}
		}

		public float DeFuzzifyMaxAv()
		{
			float bottom = 0;
			float top = 0;

			foreach(FuzzySet fuzzySet in m_dicFuzzyVariable.Values)
			{
				bottom += fuzzySet.GetDOM();
				top += fuzzySet.GetRepresentativeVal() * fuzzySet.GetDOM();

				Debug.LogWarning("DeFuzzifyMaxAv: " + "dom: " + fuzzySet.GetDOM() + "Representative: " + fuzzySet.GetRepresentativeVal());
			}

			float ret = bottom == 0 ? bottom : top / bottom;
			return ret;
		}

		public float DeFuzzifyCentroid(int numSample)
		{
			float stepSize = (m_maxRange - m_minRange) / (float)numSample;

			float totalArea = 0;
			float sumOfMoments = 0;

			for(int samp = 1; samp <= numSample; ++samp)
			{
				foreach(FuzzySet fuzzySet in m_dicFuzzyVariable.Values)
				{
					float contribution = Math.Min(fuzzySet.CalculateDOM(m_minRange + samp * stepSize), fuzzySet.GetDOM());
//					Debug.Log("contribution: " + contribution);
					totalArea += contribution;
					sumOfMoments += (m_minRange + samp * stepSize) * contribution;
				}
			}

			float ret = totalArea == 0 ? 0 : sumOfMoments / totalArea;
			return ret;
		}

		public FzSet AddCurveSet(string name, AnimationCurve curve, float unit)
		{
			m_dicFuzzyVariable[name] = new FuzzyCurveSet(curve, unit);
			AdjustRangeToFit(curve.keys[0].time * unit, curve.keys[curve.length - 1].time * unit);
			return new FzSet(m_dicFuzzyVariable[name]);
		}
	}
}

