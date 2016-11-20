using UnityEngine;
using System.Collections;

public class ZoneSpawner : MonoBehaviour {


    public GameObject prefab;
    public GameObject parentObject;
    public bool useParentObjectLayer;
	public Rect spawnZone;
	public bool showGizmo;
	public Color gizmoColor;
    public float spawnInterval = 0.15f;
	public float minDistance;
	public LayerMask layerMask;

    float timer;
    void Update()
    {
        timer += Time.deltaTime;

        if ( timer >= spawnInterval && Time.timeScale != 0)
        {
            Spawn();
        }

     
    }
	public  GameObject Spawn ()
	{
		//Vector2 pos = GetRandomPositionInZone ();
		//if (pos == Vector2.zero)
			//return null;
        timer = 0f;
        GameObject instance = ObjectPoolsManager.GetInstance().GetObject(prefab);
		instance.transform.position = transform.position;
		return instance;

	}

	Vector2 GetRandomPositionInZone() {

		float randomX, randomY;
		int maxAttempts = 10;

		for (int i = 0; i < maxAttempts; i++) {
			randomX = Random.Range (spawnZone.xMin, spawnZone.xMax);
			randomY = Random.Range (spawnZone.yMin, spawnZone.yMax);
			Vector2 pos = new Vector2 (randomX, randomY);
			if (!Physics2D.OverlapCircle (pos, minDistance, layerMask)) {
				return pos;
			}			
		}

		return Vector2.zero;
	}
	void OnDrawGizmos(){
		if (showGizmo ) {
			GizmoUtils.DrawRectangle (spawnZone, gizmoColor);
		}
	}
}
