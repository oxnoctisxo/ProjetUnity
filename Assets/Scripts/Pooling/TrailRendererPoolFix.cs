using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TrailRenderer))]
public class TrailRendererPoolFix : MonoBehaviour {

	void OnDisable(){
		GetComponent<TrailRenderer> ().Clear ();
	}
}
