using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionBehaviours : MonoBehaviour {

	public LayerMask layerMask;

	public string[] excludedTags;

	public List<AbstractBehaviour> behavioursOnSelf;
	public List<AbstractBehaviour> behavioursOnOther;

	void OnTriggerEnter2D(Collider2D col) {

		if ((col.gameObject.layer & 1 << layerMask) <= 0) {
			return;
		}

		foreach (var item in excludedTags) {
			if (item == col.gameObject.tag) {
				return;
			}
		}

		foreach (var item in behavioursOnOther) {
			item.Execute (col.gameObject.GetComponentInParent<Rigidbody2D> ().gameObject);
		}
		foreach (var item in behavioursOnSelf) {
			item.Execute (gameObject.GetComponentInParent<Rigidbody2D> ().gameObject);
		}
	}


}
