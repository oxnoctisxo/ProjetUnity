using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathManager : MonoBehaviour {

	public EventsManager eventsManager;

	public List<AbstractDieBehaviour> dieBehaviours;

	void Awake() {
		if (!eventsManager) {
			eventsManager = GetComponentInParent<EventsManager> ();
		}
		foreach (var item in GetComponentsInChildren<AbstractDieBehaviour>()) {
			dieBehaviours.Add (item);
		}
	}

	void OnEnable() {
		eventsManager.OnDie += Die;
	}

	void OnDisable() {
		eventsManager.OnDie -= Die;
	}

	void Die() {
        
		foreach (var item in dieBehaviours) {
			item.Die (gameObject);
		}
		
	}
}
