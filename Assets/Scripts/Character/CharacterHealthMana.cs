using UnityEngine;
using System.Collections;

public class CharacterHealthMana : MonoBehaviour {

	CharacterStats stats;

	float health;
	float mana;

	void Start() {
		stats = GetComponent<CharacterStats> ();
		health = stats.maxHealth;
		mana = stats.maxMana;
	}

	void FixedUpdate() {
		//TODO - placeholder void death
		if (transform.position.y <= -4) {
			health -= 10;
		}

		ModHealth(stats.healthRegen * Time.fixedDeltaTime);

		if (health > stats.maxHealth) {
			health = stats.maxHealth;
		} else if (health < 0) {
			Die ();
		}
	
		ModMana (stats.manaRegen * Time.fixedDeltaTime);

		if (mana > stats.maxHealth) {
			mana = stats.maxMana;
		} else if (mana < 0) {
			mana = 0;
		}
	}

	//Damage is inputted as a negative number
	//and Regen as a positive number
	public void ModHealth(float diff) {
		health += diff;
	}

	public void ModMana(float diff) {
		mana += diff;
	}

	//TODO - STOP MOTION AS WELL
	void Die() {
		transform.position = new Vector3 (0, 2, 0);
		health = stats.maxHealth;
	}
}