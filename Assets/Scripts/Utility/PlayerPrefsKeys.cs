using UnityEngine;
using System.Collections;

public class PlayerPrefsKeys : MonoBehaviour {

	public enum Keys {
		[Tooltip("Hi Score")]
		HiScore
	}
}

public static class PlayerPrefsKeysExtensions {

	public static string TooltipToString(this PlayerPrefsKeys.Keys key) {
		TooltipAttribute[] attributes = (TooltipAttribute[])key.GetType ()
									.GetField (key.ToString ())
									.GetCustomAttributes (typeof(TooltipAttribute), false);
		return attributes.Length > 0 ? attributes [0].tooltip : key.ToString ();

	}

}
