using UnityEngine;
using System.Collections;

public class EventsManager : MonoBehaviour {

	public delegate void DieAction();
	public delegate void EraseAction();

	public event DieAction OnDie;
	public event EraseAction OnErase;

	public void Die(){
		if(OnDie != null) {
			OnDie ();
		}
	}

	public void Erase(){
		if(OnErase != null) {
			OnErase ();
		}
	}

}
