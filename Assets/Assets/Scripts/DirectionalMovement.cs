using UnityEngine;
using System.Collections;

public class DirectionalMovement : MonoBehaviour {

	public int speed;
	public Vector3 direction;
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move() {
		transform.Translate (direction.normalized * speed * Time.deltaTime, Space.World);
	}
}
