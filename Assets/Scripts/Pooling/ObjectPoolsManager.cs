using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolsManager : AbstractSingleton<ObjectPoolsManager> {

	Dictionary <string, ObjectPool> objectPools;


	public override void Initialize ()
	{
		objectPools = new Dictionary<string, ObjectPool> ();
	}


	ObjectPool GetPool(GameObject obj) {
		ObjectPool pool;
		if (!objectPools.TryGetValue(obj.name, out pool)) {
			pool = new ObjectPool (obj);
			objectPools.Add(obj.name, pool);
		}
		return pool;
	}

	public GameObject GetObject(GameObject obj) {
		return GetPool (obj).GetObject ();
	}

	public void PoolObject(GameObject obj) {
		GetPool (obj).PoolObject (obj);
	}

}
