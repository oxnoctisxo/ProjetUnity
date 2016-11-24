using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	[Range(0,1)]
	public float minRotationSpeed;
	[Range(0,1)]
	public float maxRotationSpeed;
	public int rotationSpeedRatio;

	float rotationSpeed;
	Vector3 axis;


	// Use this for initialization
	void Start () {
		axis = Random.onUnitSphere;
		rotationSpeed = Random.Range (minRotationSpeed, maxRotationSpeed) * rotationSpeedRatio;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (axis, rotationSpeed * Time.deltaTime);
	}
}
