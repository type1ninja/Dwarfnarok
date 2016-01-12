using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {
	//All of these variables are DEFAULT ABSOLUTE values

	public float DEFAULT_maxHealth = 100f;
	//In health per second
	public float DEFAULT_healthRegen = 2.5f;
	//Percent of damage blocked
	public float DEFAULT_damageReduction = .15f;

	//manaRegen = mana/sec
	public float DEFAULT_manaRegen = 10f;
	public float DEFAULT_maxMana = 100f;
	
	public float DEFAULT_damage = 15f;
	//TODO - KNOCKBACK HAS NO REFERENCE POINT YET
	public float DEFAULT_knockback = 5.0f;
	//Number of seconds taken to swing object
	public float DEFAULT_attackTime = .75f;
	
	public float DEFAULT_speed = 10f;
	public float DEFAULT_jumpSpeed = 8f;


	
	public float healthRegen;
	public float maxHealth;
	public float damageReduction;
	
	public float manaRegen;
	public float maxMana;

	public float damage;
	public float knockback;
	public float attackTime;

	public float speed;
	public float jumpSpeed;

	//The armor is pretty much modifiable-in-game player stats
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
		float attackTime = DEFAULT_attackTime;
		
		float speed = DEFAULT_speed;
		float jumpSpeed = DEFAULT_jumpSpeed;
	}

	//TODO - REPLACE ALL OF THESE UPDATES (except maybe maxHealth/Mana) WITH GET METHODS, THIS IS PROBLY TOO LAGGY
	void FixedUpdate() {
		//Multiply EVERY value by it's corresponding armor mod every frame
		maxHealth = DEFAULT_maxHealth * armor.maxHealthMod;
		healthRegen = DEFAULT_healthRegen * armor.healthRegenMod;
		damageReduction = DEFAULT_damageReduction * armor.damageReductionMod;
		
		maxMana = DEFAULT_maxMana * armor.maxManaMod;
		manaRegen = DEFAULT_manaRegen * armor.manaRegenMod;
		
		damage = DEFAULT_damage * armor.damageMod;
		knockback = DEFAULT_knockback * armor.knockbackMod;
		attackTime = DEFAULT_attackTime * armor.attackTimeMod;
		
		speed = DEFAULT_speed * armor.speedMod;
		jumpSpeed = DEFAULT_jumpSpeed * armor.jumpSpeedMod;
		
		//TODO - PSEDUOCODE
		//This will be the code for spell effects on a player
		//for (int i = 0; i < activeEffects.Length; i++) {
		//	speed *= activeEffects[i].speedMod;
		//}
		//Repeat for all values except current health/mana
	}
}