using UnityEngine;

namespace Zkull.Fuzzy
{
	public class FuzzyCurveSet : FuzzySet
	{
		protected AnimationCurve m_curve;
		protected float m_unit;

		public FuzzyCurveSet(AnimationCurve curve, float unit)
		{
			m_curve = curve;
			m_unit = unit;
			m_representativeValue = (curve.keys[curve.length - 1].time + curve.keys[0].time) * unit / 2f;
		}
		//temp
		public AnimationCurve curve{get{return m_curve;}}

		public override float CalculateDOM (float val)
		{
			float time = val / m_unit;
			if(m_curve != null)
			{
//				Debug.Log("unit: " + m_unit + "input val/unit: " + time + " curve dom: " + m_curve.Evaluate(time));
				return m_curve.Evaluate(time);
			}
			return 0f;
		}
	}
}

