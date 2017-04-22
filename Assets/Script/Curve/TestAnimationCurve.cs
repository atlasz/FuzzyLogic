using UnityEngine;
using System.Collections;

public class TestAnimationCurve : MonoBehaviour {

	public AnimationCurveTemplate template;
	public AnimationCurve curve;
	public AnimationCurve line = AnimationCurve.Linear(0, 0, 0.5f, 1f);
	public AnimationCurve tri;
	// Use this for initialization
	void Start () {
//		Keyframe[] ks = new Keyframe[3];
//		ks[0] = new Keyframe(0, 0);
//		ks[0].tangentMode = 10;
//		ks[0].inTangent = 2f;
//		ks[0].outTangent = 2f;
//		ks[1] = new Keyframe(50f, 100f);
//		ks[1].tangentMode = 21;
//		ks[1].inTangent = 2f;
//		ks[1].outTangent = 2f;
//		ks[2] = new Keyframe(100f, 100f);
//		ks[2].tangentMode = 10;
//		ks[2].inTangent = -2f;
//		ks[2].outTangent = -2f;
//		tri = new AnimationCurve(ks);
//
//
//		for(int i = 0; i < curve.keys.Length; i++)
//		{
//			Keyframe frame = curve.keys[i];
//			Debug.Log("frame " + i + " inTangent: " + frame.inTangent + "outTangent: " + frame.outTangent
//				+ " tangentMode: " + frame.tangentMode + " time: " + frame.time + " value: " + frame.value);
//		}
//
//		curve.keys[2].value = 1f;
//		curve.keys[2].time = 0.8f;
//		curve = new AnimationCurve(curve.keys);
		curve = new AnimationCurve(template.triAngle.keys);
		Debug.Log(curve.keys[1].time);
		curve.MoveKey(1, new Keyframe(0.3f, 1f));
		Debug.Log(curve.keys[1].time);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(curve.keys[1].time);
	}
}
