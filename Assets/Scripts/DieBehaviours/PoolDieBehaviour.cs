using UnityEngine;
using System.Collections;

public class PoolDieBehaviour : AbstractDieBehaviour {

	public override void Die (GameObject deadObject)
	{
		ObjectPoolsManager.GetInstance ().PoolObject (deadObject);
	}

}
