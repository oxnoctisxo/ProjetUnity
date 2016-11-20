using UnityEngine;
using System.Collections;

public class OnErasePool : MonoBehaviour {

	public EventsManager eventsManager;

	void Awake () {
		if(!eventsManager) {
			eventsManager = GetComponentInParent<EventsManager> ();
		}
	}

	void OnEnable() {
		eventsManager.OnErase += Pool;
	}

	void OnDisable() {
		eventsManager.OnErase -= Pool;
	}

	void Pool(){
		ObjectPoolsManager.GetInstance ().PoolObject (eventsManager.gameObject);
	}
}
