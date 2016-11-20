using UnityEngine;
using System.Collections;

public class EraseOtherColliders : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		EventsManager[] evtMans = col.gameObject.GetComponentsInParent<EventsManager> ();
		evtMans [evtMans.Length - 1].Erase ();
	}
}
