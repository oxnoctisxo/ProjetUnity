using UnityEngine;
using System.Collections;

public class ClampedPosition : MonoBehaviour {

	public Rect bounds;
	public bool drawGizmo;
	public Color gizmoColor;
	
	// Update is called once per frame
	void LateUpdate () {
		ClampPosition();
	}

	void ClampPosition() {
		Vector3 newPos = transform.position;
		newPos.x = Mathf.Clamp (newPos.x, bounds.xMin, bounds.xMax);
		newPos.y = Mathf.Clamp (newPos.y, bounds.yMin, bounds.yMax);
		transform.position = newPos;
	}

	void OnDrawGizmos(){
		if (drawGizmo) {
			GizmoUtils.DrawRectangle (bounds, gizmoColor);
		}
	}


}
