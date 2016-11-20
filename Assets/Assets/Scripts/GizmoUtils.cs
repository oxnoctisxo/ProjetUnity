using UnityEngine;
using System.Collections;

public class GizmoUtils {

	public static void DrawRectangle(Rect bounds, Color col) {
		Gizmos.color = col;
		Vector2 botLeft = new Vector2 (bounds.xMin, bounds.yMin);
		Vector2 topLeft = new Vector2 (bounds.xMin, bounds.yMax);
		Vector2 topRight = new Vector2 (bounds.xMax, bounds.yMax);
		Vector2 botRight = new Vector2 (bounds.xMax, bounds.yMin);
		Gizmos.DrawLine (botLeft, topLeft);
		Gizmos.DrawLine (topLeft, topRight);
		Gizmos.DrawLine (topRight, botRight);
		Gizmos.DrawLine (botRight, botLeft);
	}

}
