using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour {

	// La santé du jeu
	public PlayerHealth playerHealth;   
	// Zone buffer pour éviter que les ennemies spawnent dans le champ de la caméra
	public float bufferDistance = 210;
	// Temps entre chaque vague
	public float timeBetweenWaves = 5f;
	// Temps entre chaque spawn
	public float spawnTime = 3f;
	// Quelle vague au début
	public int startingWave = 1;
	// Difficulté par défaut
	public int startingDifficulty = 1;
	// Nombre d'ennemies vivants dans la vague
	[HideInInspector]
	public int enemiesAlive = 0;

	// Description d'une vague et de chaque element y faisant partie.
	[System.Serializable]
	public class Wave {
		public Element[] elements;

		// Element d'une vague
		[System.Serializable]
		public class Element {
			// Le genre d'ennemi à spawn
			public GameObject enemy;
			// Le nombre d'ennemis à spawn
			public int ennemyCount;
			// nombre d'ennemies déja spawné
			[System.NonSerialized]
			public int spawned;
		}

	}

	// Tout les vagues de la scène
	public Wave[] waves;

	// Variables
	Vector3 spawnPosition = Vector3.zero;
	int waveNumber;
	float timer; 
	Wave currentWave;
	int spawnedThisWave = 0;
	int totalToSpawnForWave;
	bool shouldSpawn = false;
	int difficulty;

	void Start() {
		// Permet de mettre une difficulté plus élévée
		waveNumber = startingWave > 0 ? startingWave - 1 : 0;
		difficulty = startingDifficulty;

		// Coroutine pour démarrer les vagues
		StartCoroutine("NextWave");
	}

	void Update() {
		// Empêche de faire spawn le temps qu'on change de vague
		if (!shouldSpawn) {
			return;
		}

		// Démarre la prochaine vague quand tout les ennemies de la vague sont morts
		if (spawnedThisWave == totalToSpawnForWave && enemiesAlive == 0) {
			StartCoroutine("NextWave");
			return;
		}

		// Delta time pour savoir si on doit spawn un enemi
		timer += Time.deltaTime;

		if (timer >= spawnTime) {
			// Spawn d'ennemi de la vague
			foreach (Wave.Element entry in currentWave.elements) {
				if (entry.spawned < (entry.ennemyCount * difficulty)) {
					Spawn(entry);
				}
			}
		}
	}

	// coroutine
	IEnumerator NextWave() {
		shouldSpawn = false;

		yield return new WaitForSeconds(timeBetweenWaves);

		if (waveNumber == waves.Length) {
			waveNumber = 0;
			difficulty++;
		}

		currentWave = waves[waveNumber];

		// multiplicateur de spawn d'ennemies en fonction de la difficulté
		totalToSpawnForWave = 0;
		foreach (Wave.Element entry in currentWave.elements) {
			totalToSpawnForWave += (entry.ennemyCount * difficulty);
		}

		spawnedThisWave = 0;
		shouldSpawn = true;

		waveNumber++;

	}


	// Spawn d'ennemies.
	void Spawn(Wave.Element element) {
		// restart le timer
		timer = 0f;

		// si le joueur est mort, on arrête le spawning
		if (playerHealth.currentHealth <= 0f) {
			return;
		}

		// trouve une position sur le plateau de jeu
		Vector3 randomPosition = Random.insideUnitSphere * 35;
		randomPosition.y = 0;

		// tente de trouver un endroit de spawn près de la position.
		NavMeshHit hit;
		if (!NavMesh.SamplePosition (randomPosition, out hit, 5, 1)) {
			return;
		}

		// Si position valide
		spawnPosition = hit.position;

		// check pour voir si le joueur voit le spawn de l'ennemi ou pas
		Vector3 screenPos = Camera.main.WorldToScreenPoint(spawnPosition);
		if ((screenPos.x > -bufferDistance && screenPos.x < (Screen.width + bufferDistance)) && 
			(screenPos.y > -bufferDistance && screenPos.y < (Screen.height + bufferDistance))) 
		{
			return;
		}

		// on a passé tout les checks donc on spawn
		GameObject enemy =  (GameObject) Instantiate(element.enemy, spawnPosition, Quaternion.identity);
		// Augmente la santé de l'ennemi en fonction de la difficulté
		enemy.GetComponent<EnemyHealth>().startingHealth *= difficulty;
		//enemy.GetComponent<EnemyHealth>().scoreValue *= difficulty;

		element.spawned++;
		spawnedThisWave++;
		enemiesAlive++;
	}
}
