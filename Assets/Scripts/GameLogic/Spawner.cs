using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemyObject;

	GameState state;
	
	double timeUntilSpawn = 0;
	double maxTimeBetweenSpawns = 10;

	void Start() {
		state = GameObject.Find ("GameLogicScripts").GetComponent<GameState> ();
	}

	void FixedUpdate() {
		if (state.GetEnemiesAttacking()) {
			if (timeUntilSpawn <= 0) {
				Instantiate (enemyObject, gameObject.transform.position, Quaternion.identity);
				timeUntilSpawn = maxTimeBetweenSpawns;
			}

			timeUntilSpawn -= Time.fixedDeltaTime;
		}
	}
}