using UnityEngine;
using System.Collections;
[CreateAssetMenu(menuName="Behaviours/Pool Behaviour")]
public class PoolBehaviour : AbstractBehaviour {

	public override void Execute (GameObject targetObject)
	{
		ObjectPoolsManager.GetInstance ().PoolObject (targetObject);
	}

}
