using UnityEngine;
using System.Collections;

public abstract class CharacterHealthMana : MonoBehaviour {

	//Void damage per second
	float VOIDDMGPERSEC = -75;

	protected CharacterStats stats;
	protected CharacterMove move;

	protected float health;
	protected float mana;

	bool hasSetFirstStats = false;

	void Start() {
		stats = GetComponent<CharacterStats> ();
		move = GetComponent<CharacterMove> ();
	}

	void FixedUpdate() {

		if (!hasSetFirstStats) {
			health = stats.GetMaxHealth ();
			mana = stats.GetMaxMana ();

			hasSetFirstStats = true;
		}

		//Void Death
		if (transform.position.y <= -100) {
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
	
	protected abstract void Die ();

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