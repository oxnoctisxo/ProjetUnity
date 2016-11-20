using UnityEngine;
using System.Collections;
[CreateAssetMenu(menuName="Behaviours/Score Behaviour")]
public class ScoreBehaviour : AbstractBehaviour {

	public int score;

	public override void Execute (GameObject targetObject)
	{
		//ScoreManager.GetInstance ().AddScore (score);
	}
}
