using UnityEngine;
using System.Collections;

public class DestroyDieBehaviour : AbstractDieBehaviour {

	public override void Die (GameObject deadObject)
	{
       
		Destroy (deadObject);
	}



}
