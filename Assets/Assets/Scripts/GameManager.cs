using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : AbstractSingleton<GameManager> {
	#region implemented abstract members of AbstractSingleton

	public override void Initialize ()
	{
	}

	#endregion

	public delegate void GameAction();
	public event GameAction OnGameOver;

	public void GameOver() {
		if (OnGameOver != null) {
			OnGameOver ();
		}
	}

	public void Restart() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void Quit() {
		Application.Quit ();
	}


}
