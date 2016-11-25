using UnityEngine;
using System.Collections;

public class PoolDieBehaviour : AbstractAsyncDieBehaviour
{

	public override void Die (GameObject deadObject)
	{
		ObjectPoolsManager.GetInstance ().PoolObject (deadObject);
        isFinished = true;
    }

}
