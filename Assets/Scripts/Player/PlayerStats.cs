using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	//All of these variables are ABSOLUTE values

	public float DEFAULT_maxHealth = 100f;
	public float DEFAULT_healthRegen = 7.5f;
	//Percent of damage blocked
	public float DEFAULT_damageReduction = .15f;

	//manaRegen = mana/sec
	public float DEFAULT_manaRegen = 10f;
	public float DEFAULT_maxMana = 100f;
	
	public float DEFAULT_damage = 15f;
	//TODO - KNOCKBACK HAS NO REFERENCE POINT YET
	public float DEFAULT_knockback = 5.0f;
	//Number of seconds taken to swing object
	public float DEFAULT_attackSpeed = 1.5f;
	
	public float DEFAULT_speed = 10f;
	public float DEFAULT_jumpSpeed = 8f;



	public float currentHealth;
	public float healthRegen;
	public float maxHealth;
	public float damageReduction;

	public float currentMana;
	public float manaRegen;
	public float maxMana;

	public float damage;
	public float knockback;
	//TODO - FIGURE OUT ATTACK SPEED IN GENERAL
	public float attackSpeed;

	public float speed;
	public float jumpSpeed;

	//The armor is pretty much just player stats
	Armor armor = new Armor();

	void Start() {
		//Set all stats to defaults
		float maxHealth = DEFAULT_maxHealth;
		float currentHealth = maxHealth;
		float healthRegen = DEFAULT_healthRegen;
		float damageReduction = DEFAULT_damageReduction;

		float maxMana = DEFAULT_maxMana;
		float currentMana = maxMana;
		float manaRegen = DEFAULT_manaRegen;
		
		float damage = DEFAULT_damage;
		float knockback = DEFAULT_knockback;
		float attackSpeed = DEFAULT_attackSpeed;
		
		float speed = DEFAULT_speed;
		float jumpSpeed = DEFAULT_jumpSpeed;
	}

	void FixedUpdate() {
		//Multiply EVERY value by it's corresponding armor mod every frame
		maxHealth = DEFAULT_maxHealth * armor.maxHealthMod;
		healthRegen = DEFAULT_healthRegen * armor.healthRegenMod;
		damageReduction = DEFAULT_damageReduction * armor.damageReductionMod;
		
		maxMana = DEFAULT_maxMana * armor.maxManaMod;
		manaRegen = DEFAULT_manaRegen * armor.manaRegenMod;
		
		damage = DEFAULT_damage * armor.damageMod;
		knockback = DEFAULT_knockback * armor.knockbackMod;
		attackSpeed = DEFAULT_attackSpeed * armor.attackSpeedMod;
		
		speed = DEFAULT_speed * armor.speedMod;
		jumpSpeed = DEFAULT_jumpSpeed * armor.jumpSpeedMod;
		
		Debug.Log (attackSpeed);
		
		//TODO - PSEDUOCODE
		//for (int i = 0; i < activeEffects.Length; i++) {
		//	speed *= activeEffects[i].speedMod;
		//}
		//Repeat for all values except current health/mana

		currentHealth += healthRegen * Time.fixedDeltaTime;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		} else if (currentHealth < 0) {
			//TODO - DIE
			currentHealth = maxHealth;
		}

		currentMana += manaRegen * Time.fixedDeltaTime;
		if (currentMana > maxHealth) {
			currentMana = maxMana;
		} else if (currentMana < 0) {
			currentMana = 0;
		}
	}
}