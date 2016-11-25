using UnityEngine;
using System.Collections;

public class GameOverDieBehaviour : AbstractAsyncDieBehaviour
{

	public override void Die (GameObject deadObject)
	{
		GameManager.GetInstance ().GameOver ();
        isFinished = true;
    }




}
