using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool  {

	private List<GameObject> pool = new List<GameObject> ();
	public GameObject prefab;

	public ObjectPool(GameObject obj) {
		prefab = obj;
	}

	public GameObject GetObject(){
		GameObject obj;
		if (pool.Count == 0) {
			obj = Object.Instantiate (prefab);
			obj.name = prefab.name;
			obj.SetActive (true);
			return obj;
		}

		obj = pool [0];
		pool.RemoveAt (0);
		obj.SetActive (true);

		return obj;
	}

	public void PoolObject(GameObject obj){

		if (pool.IndexOf(obj) < 0) {
			pool.Add (obj);
			obj.SetActive (false);
		}
	}

}
