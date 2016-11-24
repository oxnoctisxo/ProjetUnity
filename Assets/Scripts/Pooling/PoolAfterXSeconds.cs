using UnityEngine;
using System.Collections;

public class PoolAfterXSeconds : MonoBehaviour {

	public float delay;

	void OnEnable(){
		Invoke ("Pool", delay);
	}

	void Pool() {
		ObjectPoolsManager.GetInstance ().PoolObject (gameObject);
	}
}
