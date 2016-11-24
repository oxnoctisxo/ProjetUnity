using UnityEngine;
using System.Collections;

public class CameraZooming : MonoBehaviour {

    float originalFOV;
    float originalOS;

    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        originalFOV = cam.fieldOfView;
        originalOS = cam.orthographicSize;

        
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKeyDown(KeyCode.PageDown) )
        {
            if (cam.fieldOfView <= 125)
                cam.fieldOfView += 2;
            if (cam.orthographicSize <= 20)
                cam.orthographicSize += 0.5f;

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKeyDown(KeyCode.PageUp))
        {
            if (cam.fieldOfView > 2)
                cam.fieldOfView -= 2;
            if (cam.orthographicSize >= 1)
                cam.orthographicSize -= 0.5f;
        }

        if (Input.GetMouseButtonDown(2))
        {
            cam.fieldOfView = originalFOV;
            cam.orthographicSize = originalOS;
        }


	}
}
