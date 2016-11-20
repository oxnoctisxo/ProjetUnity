using UnityEngine;
using System.Collections;

public class ExplodeDieBehaviour : AbstractDieBehaviour {

	public GameObject explosionPrefab;

	public override void Die (GameObject deadObject)
	{
		GameObject explosion = ObjectPoolsManager.GetInstance ().GetObject (explosionPrefab);
		explosion.transform.position = deadObject.transform.position;
		explosion.transform.rotation = Quaternion.identity;
	}

}
