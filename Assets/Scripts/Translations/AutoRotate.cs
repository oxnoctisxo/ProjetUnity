using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {
 
 
    public int speed;
    public bool rotate;


    Vector3 basePosition;
    Quaternion baseRotation;
	// Use this for initialization
	void Awake() {
        basePosition = transform.position;
        baseRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (rotate)
            transform.RotateAround(gameObject.transform.position, Vector3.up, speed  * Time.deltaTime);
        else
        {
            transform.Translate(basePosition );
           transform.rotation = baseRotation;
        }
	}

    public void AutoRotateArround()
    {
        rotate = true;
    }

    public void StopRotateArround()
    {
        rotate = false;
    }
}
