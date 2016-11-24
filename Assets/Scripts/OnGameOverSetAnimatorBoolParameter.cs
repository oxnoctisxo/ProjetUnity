using UnityEngine;
using System.Collections;

public class OnGameOverSetAnimatorBoolParameter : MonoBehaviour {

	public Animator animator;
	public string parameterName;
	public bool targetValue;

	void Awake () {
		if (!animator) {
			animator = GetComponent<Animator> ();
			if(!animator) {
				Debug.LogError ("You forgot an animator");
			}
		}
	}

	void SetAnimatorBoolParameter() {
		animator.SetBool (parameterName, targetValue);
	}

	void OnEnable() {
		GameManager.GetInstance ().OnGameOver += SetAnimatorBoolParameter;
	}
	void OnDisable() {
		GameManager.GetInstance ().OnGameOver -= SetAnimatorBoolParameter;
	}


}
