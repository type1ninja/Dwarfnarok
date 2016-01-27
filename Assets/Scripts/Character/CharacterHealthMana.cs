using UnityEngine;
using System.Collections;

public class CharacterHealthMana : MonoBehaviour {

	//Void damage per second
	float VOIDDMGPERSEC = -750;

	CharacterStats stats;

	float health;
	float mana;

	//TODO - REMOVE DAMAGE TIMER, REPLACE WITH "DON'T TAKE DAMAGE MORE THAN ONCE PER HIT BY A SINGLE WEP"
	//Don't take damage more than twice a second. Otherwise you would be _eviscerated._
	float dmgTimerMax;
	float dmgTimer;
	bool hasTakenDamage = false;

	//TODO - Health starts at 0 because the Stats script doesn't initialize fast enough.
	//Right now you just need to regen
	void Start() {
		stats = GetComponent<CharacterStats> ();
		health = stats.GetMaxHealth();
		mana = stats.GetMaxMana();
		dmgTimerMax = stats.GetDamageTimer ();
		dmgTimer = dmgTimerMax;
	}

	void FixedUpdate() {
		//TODO - MAKE A HEALTH BAR FOR THE PLAYER AND FOR ENEMIES

		//Void Death
		if (transform.position.y <= -4) {
			ModHealth(VOIDDMGPERSEC * Time.fixedDeltaTime);
		}

		if (hasTakenDamage) {
			dmgTimer -= Time.fixedDeltaTime;
			if (dmgTimer < 0) {
				hasTakenDamage = false;
				dmgTimer = dmgTimerMax;
			}
		}

		if (health > stats.GetMaxHealth()) {
			health = stats.GetMaxHealth();
		} else if (health < 0) {
			Die ();
		}

		if (mana > stats.GetMaxHealth()) {
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

		if (diff < 0) {
			if (!hasTakenDamage) {
				health += diff;
				hasTakenDamage = true;
			}
		} else {
			health += diff;
		}
	}

	public void ModMana(float diff) {
		mana += diff;
	}

	//TODO - STOP MOTION AS WELL
	void Die() {
		transform.position = new Vector3 (0, 5, 0);
		health = stats.GetMaxHealth();
	}

	public float GetHealth() {
		return health;
	}

	//Check if you're being intersected by a weapon
	void OnTriggerStay(Collider other) {
		//Check if it's a child of yourself
		if (!other.transform.IsChildOf (transform)) {

			//Check if it's supposed to do damage
			if (other.tag.Equals ("DealsDamage")) {

				//Check if it's a Player or AI (as opposed to a trap or something)
				if (other.transform.root.tag.Equals ("Player") || other.transform.root.tag.Equals ("AI")) {

					//Check if they're actually swinging at you - just walking into weapons would be bad
					if (other.transform.root.GetComponent<CharacterWepControl> ().isSwinging) {

						//Actually deal the damage :P
						ModHealth (-1 * other.GetComponentInParent<CharacterWepControl> ().GetDamage ());
						//TODO - KNOCKBACK
					}
				} //else if (isSomeOtherDamager) { - This could be for traps and stuff
			}
		}
	}
}