using UnityEngine;
using System.Collections;

public class DestroyDieBehaviour : AbstractAsyncDieBehaviour
{

	public override void Die (GameObject deadObject)
	{
		Destroy (deadObject);
        isFinished = true;
    }



}
