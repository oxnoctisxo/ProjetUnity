using UnityEngine;
using System.Collections;

public class CamShake: MonoBehaviour {

	public float duration;
	public float magnitude;

	private static bool isShaking;

	void OnEnable() {
		if(!isShaking) {
			isShaking = true;
			StartCoroutine (Shake ());
		}
	}

	void OnDisable() {
		StopCoroutine (Shake ());
		isShaking = false;
	}


	private IEnumerator Shake() {
		float elapsedTime = 0.0f;

		Vector3 originalPos = Camera.main.transform.position;

		while (elapsedTime < duration) {
			elapsedTime += Time.deltaTime;

			float percentComplete = Mathf.Min(elapsedTime / duration, 1.0f);

			float damper = 1.0f - Mathf.Clamp (4.0f * percentComplete - 3.0f,0.0f, 1.0f);

			Vector2 offset = Random.insideUnitCircle * damper * magnitude;

			Camera.main.transform.position = originalPos + new Vector3(offset.x, offset.y, 0);
			yield return null;
		}

		Camera.main.transform.position = originalPos;

		isShaking = false;

		Destroy (gameObject);
	}

}
