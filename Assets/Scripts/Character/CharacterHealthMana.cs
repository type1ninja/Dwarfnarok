using UnityEngine;
using System.Collections;

public class CharacterHealthMana : MonoBehaviour {

	//Void damage per second
	float VOIDDMGPERSEC = -750;

	CharacterStats stats;

	float health;
	float mana;

	bool hasSetFirstHealth = false;
	
	//Right now you just need to regen
	void Start() {
		stats = GetComponent<CharacterStats> ();
	}

	void FixedUpdate() {

		if (!hasSetFirstHealth) {
			Die ();
			hasSetFirstHealth = true;
		}

		//Void Death
		if (transform.position.y <= -4) {
			ModHealth(VOIDDMGPERSEC * Time.fixedDeltaTime);
		}

		if (health > stats.GetMaxHealth()) {
			health = stats.GetMaxHealth();
		} else if (health < 0) {
			Die ();
		}

		if (mana > stats.GetMaxMana()) {
			mana = stats.GetMaxMana();
		} else if (mana < 0) {
			mana = 0;
		}

		//Regen
		ModHealth(stats.GetHealthRegen() * Time.fixedDeltaTime);
		ModMana (stats.GetManaRegen() * Time.fixedDeltaTime);
	}

	//Damage is inputted as a negative number
	//and Regen as a positive number
	public void ModHealth(float diff) {
		//Reduce damage taken by the armor value
		diff *= (1 - stats.GetDamageReduction());

		health += diff;
	}

	public void ModMana(float diff) {
		mana += diff;
	}

	//TODO - STOP MOTION AS WELL
	void Die() {
		transform.position = new Vector3 (0, 5, 0);
		health = stats.GetMaxHealth();
	}

	public float GetMaxHealth() {
		return stats.GetMaxHealth ();
	}

	public float GetHealth() {
		return health;
	}

	public float GetMaxMana() {
		return stats.GetMaxMana ();
	}

	public float GetMana() {
		return mana;
	}
}