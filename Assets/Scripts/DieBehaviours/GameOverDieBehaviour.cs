using UnityEngine;
using System.Collections;

public class GameOverDieBehaviour : AbstractDieBehaviour {
	#region implemented abstract members of AbstractDieBehaviour

	public override void Die (GameObject deadObject)
	{
		GameManager.GetInstance ().GameOver ();
	}

	#endregion



}
