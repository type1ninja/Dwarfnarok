using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {
	//All of these variables are DEFAULT ABSOLUTE values

	float DEFAULT_maxHealth = 100f;
	//In health per second
	float DEFAULT_healthRegen = 2.5f;
	//Percent of damage blocked
	float DEFAULT_damageReduction = .15f;
	//The time period during which you are invincible after taking damage
	float DEFAULT_damageTimer = .5f;

	//manaRegen = mana/sec
	float DEFAULT_manaRegen = 10f;
	float DEFAULT_maxMana = 100f;
	
	float DEFAULT_damage = 25f;
	//TODO - KNOCKBACK HAS NO REFERENCE POINT YET
	float DEFAULT_knockback = 5.0f;
	//Number of seconds taken to swing object
	float DEFAULT_attackTime = .75f;
	
	float DEFAULT_speed = 10f;
	float DEFAULT_jumpSpeed = 8f;

	//The armor is pretty much modifiable-in-game player stats
	Armor armor = new Armor();

	//TODO - PSEDUOCODE
	//This will be the code for spell effects on a player
	//for (int i = 0; i < activeEffects.Length; i++) {
	//	speed *= activeEffects[i].speedMod;
	//}
	//Repeat for all values except current health/mana

	//The Getter methods - these return the default value * the armor modifier
	public float GetHealthRegen() {
		return DEFAULT_healthRegen * armor.healthRegenMod;
	}
	public float GetMaxHealth() {
		return DEFAULT_maxHealth * armor.maxHealthMod;
	}
	public float GetDamageReduction() {
		return DEFAULT_damageReduction * armor.damageReductionMod;
	}
	public float GetDamageTimer() {
		return DEFAULT_damageTimer * armor.damageTimerMod;
	}
	public float GetMaxMana() {
		return DEFAULT_maxMana * armor.maxManaMod;
	}
	public float GetManaRegen() {
		return DEFAULT_manaRegen * armor.manaRegenMod;
	}
	public float GetDamage() {
		return DEFAULT_damage * armor.damageMod;
	}
	public float GetKnockback() {
		return DEFAULT_knockback * armor.knockbackMod;
	}
	public float GetAttackTime() {
		return DEFAULT_attackTime * armor.attackTimeMod;
	}
	public float GetSpeed() {
		return DEFAULT_speed * armor.speedMod;
	}
	public float GetJumpSpeed() {
		return DEFAULT_jumpSpeed * armor.speedMod;
	}
}