using UnityEngine;
using System.Collections;

public class CamShakeDieBehaviour : AbstractDieBehaviour {

	public float duration;
	[Range(0,5)]
	public float magnitude;

	public CamShake shakeObj;

	public override void Die (GameObject deadObject)
	{
		CamShake shake = (CamShake)Instantiate (shakeObj);
		shake.duration = duration;
		shake.magnitude = magnitude;
	}

}
