using UnityEngine;
using System.Collections;

public class KeyboardMovement : MonoBehaviour {

	public int speed;
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move() {
		float xOffset = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		float yOffset = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;
		Vector3 newPos = transform.position;
		newPos += new Vector3 (xOffset, yOffset, 0);
		transform.position = newPos;
	}
}
