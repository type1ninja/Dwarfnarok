using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {
	//All of these variables are DEFAULT ABSOLUTE values

	float DEFAULT_maxHealth = 100f;
	//In health per second
	float DEFAULT_healthRegen = 2.5f;
	//Percent of damage blocked by armor
	float DEFAULT_damageReduction = .15f;

	//manaRegen = mana/sec
	float DEFAULT_manaRegen = 10f;
	float DEFAULT_maxMana = 100f;
	
	float DEFAULT_damage = 25f;
	float DEFAULT_knockback = 30f;
	//Number of seconds taken to swing object
	float DEFAULT_attackTime = .75f;
	
	float DEFAULT_speed = 10f;
	float DEFAULT_jumpSpeed = 8f;

	//The armor is pretty much modifiable-in-game player stats
	public Armor armor = new Armor();
	CharacterEffects charEffects;

	void Start() {
		charEffects = GetComponent<CharacterEffects> ();
	}

	//TODO - PSEDUOCODE
	//This will be the code for spell effects on a player
	//Place this inside the getter methods for each value
	//for (int i = 0; i < activeEffects.Length; i++) {
	//	speed *= activeEffects[i].speedMod;
	//}

	//The Getter methods - these return the default value * the armor modifier * every spell modifier
	public float GetMaxHealth() {
		return DEFAULT_maxHealth * armor.maxHealthMod * charEffects.GetMaxHealthMod();
	}
	public float GetHealthRegen() {
		return DEFAULT_healthRegen * armor.healthRegenMod * charEffects.GetHealthRegenMod ();
	}
	public float GetDamageReduction() {
		return DEFAULT_damageReduction * armor.damageReductionMod* charEffects.GetDamageReductionMod ();
	}
	public float GetMaxMana() {
		return DEFAULT_maxMana * armor.maxManaMod * charEffects.GetMaxManaMod ();
	}
	public float GetManaRegen() {
		return DEFAULT_manaRegen * armor.manaRegenMod * charEffects.GetManaRegenMod ();
	}
	public float GetDamage() {
		return DEFAULT_damage * armor.damageMod * charEffects.GetDamageMod ();
	}
	public float GetKnockback() {
		return DEFAULT_knockback * armor.knockbackMod * charEffects.GetKnockbackMod ();
	}
	public float GetAttackTime() {
		return DEFAULT_attackTime * armor.attackTimeMod * charEffects.GetAttackTimeMod ();
	}
	public float GetSpeed() {
		return DEFAULT_speed * armor.speedMod * charEffects.GetSpeedMod ();
	}
	public float GetJumpSpeed() {
		return DEFAULT_jumpSpeed * armor.speedMod * charEffects.GetJumpSpeedMod ();
	}
}