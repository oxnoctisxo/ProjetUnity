using UnityEngine;
using System.Collections;

public class LogCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log ("I collided with " + col.gameObject.name);
	}

}
