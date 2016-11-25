using UnityEngine;
using System.Collections;

public class ScoreDieBehaviour : AbstractAsyncDieBehaviour {

	public int score;

	public override void Die (GameObject deadObject)
	{
		ScoreManager.GetInstance ().AddScore (score);
        isFinished = true;
    }
}
