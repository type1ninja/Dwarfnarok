using UnityEngine;
using System.Collections;

//The effects a spell has on someone
public class SpellEffect {

	//Instantly applied effects
	//Can be negative
	public float instantDamage = 0f;
	public float instantKnockback = 0f;

	//Effects that last the duration
	public float maxHealthMod = 1f;
	public float healthRegenMod = 1f;
	public float damageReductionMod = 1f;
	public float maxManaMod = 1f;
	public float manaRegenMod = 1f;
	public float damageMod = 1f;
	public float attackTimeMod = 1f;
	public float knockbackMod = 1f;
	public float speedMod = 1f;
	public float jumpSpeedMod = 1f;

	//TODO - make duration private
	public float duration = 3f;

	//Just have everything be default
	public SpellEffect() { }

	//For creating spells from templates -- necessary because when I tried
	//setting ProjectileSpell's effect field equal to the template effect,
	//it was a reference instead of a variable
	public SpellEffect (SpellEffect templateEffect) {
		instantDamage = templateEffect.instantDamage;
		instantKnockback = templateEffect.instantKnockback;

		maxHealthMod = templateEffect.maxHealthMod;
		healthRegenMod = templateEffect.healthRegenMod;
		damageReductionMod = templateEffect.damageReductionMod;
		maxManaMod = templateEffect.maxManaMod;
		damageMod = templateEffect.damageMod;
		attackTimeMod = templateEffect.attackTimeMod;
		knockbackMod = templateEffect.knockbackMod;
		speedMod = templateEffect.speedMod;
		jumpSpeedMod = templateEffect.jumpSpeedMod;

		duration = templateEffect.duration;
	}

	public void DecrementTime(float decrement = 0) {
		if (decrement != 0) {
			duration -= decrement;
		} else {
			duration -= Time.fixedDeltaTime;
		}
	}

	public bool IsDurationOver() {
		if (duration <= 0) {
			return true;
		} else {
			return false;
		}
	}

	//Use this to check whether an effect is already on someone, then just refresh the duration if it is
	public bool Equals(SpellEffect otherEffect) {
		if (instantDamage == otherEffect.instantDamage && instantKnockback == otherEffect.instantKnockback && maxHealthMod == otherEffect.maxHealthMod
			&& healthRegenMod == otherEffect.healthRegenMod && damageReductionMod == otherEffect.damageReductionMod && maxManaMod == otherEffect.maxManaMod 
			&& manaRegenMod == otherEffect.manaRegenMod && damageMod == otherEffect.damageMod && attackTimeMod == otherEffect.attackTimeMod 
			&& knockbackMod == otherEffect.knockbackMod && speedMod == otherEffect.speedMod && jumpSpeedMod == otherEffect.jumpSpeedMod) 
		{
			//All the effects are equal
			return true;
		} else {
			//One or more effects is not equal
			return false;
		}
	}

	public void SetDuration(float newDur) {
		duration = newDur;
	}
}