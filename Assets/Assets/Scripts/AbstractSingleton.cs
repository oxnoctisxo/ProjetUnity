using UnityEngine;
using System.Collections;

public abstract class AbstractSingleton <T> : MonoBehaviour where T : AbstractSingleton<T> {

	private static T instance;

	public static T GetInstance() {
		if (!instance) {
			instance = FindObjectOfType<T> ();
			if (!instance) {
				Debug.LogError("There needs to be at least one active object of type " + typeof(T)
					+ " on the scene.");
				return null;
			}
			instance.Initialize ();
		}
		return instance;
	}

	public abstract void Initialize ();

}
