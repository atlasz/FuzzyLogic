using UnityEngine;
using System.Collections;
using Zkull.Fuzzy;

public class bootstrap : MonoBehaviour 
{
	public AnimationCurveTemplate template;
	private FuzzyModule m_module;
	// Use this for initialization
	void Start () 
	{
		m_module = new FuzzyModule();

		FuzzyVariable fvDistToTarget = m_module.CreateFLV("DistToTarget");
		FuzzyVariable fvDesirability = m_module.CreateFLV("Desirability");
		FuzzyVariable fvAmmoStatus = m_module.CreateFLV("AmmoStatus");

		AnimationCurve curveDist0 = new AnimationCurve(template.leftShoulder.keys);
		AnimationCurve curveDist1 = new AnimationCurve(template.triAngle.keys);
		AnimationCurve curveDist2 = new AnimationCurve(template.rightShoulder.keys);

//		curveDist2.Evaluate(2f);

		FzSet Bad_Health = fvDistToTarget.AddCurveSet("Bad_Health", curveDist0, 100f);
		FzSet Normal_Health = fvDistToTarget.AddCurveSet("Normal_Health", curveDist1, 100f);
		FzSet Good_Health = fvDistToTarget.AddCurveSet("Good_Health", curveDist2, 100f);

		FzSet Cover_Good = fvAmmoStatus.AddCurveSet("Cover_Good", template.am0, 100f);
		FzSet Cover_Normal = fvAmmoStatus.AddCurveSet("Cover_Normal", template.am1, 100f);
		FzSet Cover_Poor = fvAmmoStatus.AddCurveSet("Cover_Poor", template.am2, 100f);

		FzSet VeryDesirable = fvDesirability.AddCurveSet("VeryDesirable", template.d0, 100f);
		FzSet Desirable = fvDesirability.AddCurveSet("Desirable", template.d1, 100f);
		FzSet Undesirable = fvDesirability.AddCurveSet("Undesirable", template.d2, 100f);

//		m_module.AddRule(new FzAND(Bad_Health, Cover_Good), new FzFairly(Desirable));
//		m_module.AddRule(new FzAND(Bad_Health, Cover_Normal),  new FzFairly(Desirable));
//		m_module.AddRule(new FzAND(Bad_Health, Cover_Poor), Undesirable);
//
//		m_module.AddRule(new FzAND(Normal_Health, Cover_Good), VeryDesirable);
//		m_module.AddRule(new FzAND(Normal_Health, Cover_Normal), Desirable);
//		m_module.AddRule(new FzAND(Normal_Health, Cover_Poor), Desirable);
//
//		m_module.AddRule(new FzAND(Good_Health, Cover_Good), new FzVery(VeryDesirable));
//		m_module.AddRule(new FzAND(Good_Health, Cover_Normal), new FzVery(VeryDesirable));
//		m_module.AddRule(new FzAND(Good_Health, new FzFairly(Cover_Poor)), VeryDesirable);

		m_module.AddRule(new FzAND(Good_Health, Cover_Good), Desirable);
		m_module.AddRule(new FzAND(Good_Health, Cover_Normal), Undesirable);
		m_module.AddRule(new FzAND(Good_Health, Cover_Poor), Undesirable);

		m_module.AddRule(new FzAND(Normal_Health, Cover_Good), VeryDesirable);
		m_module.AddRule(new FzAND(Normal_Health, Cover_Normal), VeryDesirable);
		m_module.AddRule(new FzAND(Normal_Health, Cover_Poor), Desirable);

		m_module.AddRule(new FzAND(Bad_Health, Cover_Good), Undesirable);
		m_module.AddRule(new FzAND(Bad_Health, Cover_Normal),  Undesirable);
		m_module.AddRule(new FzAND(Bad_Health, Cover_Poor), Undesirable);
		GameObject currentTarget;
		//test
//		Debug.LogError(Good_Health.c(200f));
//		Debug.LogError(Cover_Good.GetDOM(8

		m_module.Fuzzify("Health", GetCurrentHealth());
		m_module.Fuzzify("CoverStatus", GetCloseCoverState());


		Debug.LogError("max_av score: " + m_module.Defuzzify("Desirability", DefuzzifyMethod.MAX_AV));

		Debug.LogError("centroid score: " + m_module.Defuzzify("Desirability", DefuzzifyMethod.CENTROID));
	}

	private float GetCurrentHealth()
	{
		return 0;
	}

	private int GetCloseCoverState()
	{
		return 0;
	}

	private float GetCurrentBulletNum()
	{
		return 0;
	}

	private float GetDistFromTarget(GameObject player)
	{
		return 0;
	}
}
