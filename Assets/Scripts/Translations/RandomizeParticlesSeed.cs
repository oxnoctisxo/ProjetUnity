using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class RandomizeParticlesSeed : MonoBehaviour {

	void Awake() {
		GetComponent<ParticleSystem> ().randomSeed = 0;
	}

}
