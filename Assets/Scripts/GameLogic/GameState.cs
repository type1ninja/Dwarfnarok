using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	bool enemiesAttacking;

	public void SetEnemiesAttacking(bool newState) {
		enemiesAttacking = newState;
	}

	public bool GetEnemiesAttacking() {
		return enemiesAttacking;
	}
}