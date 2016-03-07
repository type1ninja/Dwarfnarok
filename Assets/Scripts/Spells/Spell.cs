using UnityEngine;
using System.Collections;

//These are the other properties spell has, aside from the direct effects
public class Spell {

	static float BASIC_MANA_COST = 10f;

	public SpellEffect effect;
	
	public float manaCost;
	public float attackTime = .75f;
	public float projectileSpeed = 3000f;

	public Spell() {
		effect = new SpellEffect ();
		//TODO - TEMPORARY DEFAULT VALUES
		effect.instantDamage = 25f;
		effect.healthRegenMod = 0f;

		//TODO - MAKE MANA COST MAKE SENSE
		//Mana cost = all of the modifiers times each other, times the instant damage and knockback divided by 2
		manaCost = BASIC_MANA_COST; //* (effect.instantDamage / 2) * (effect.instantKnockback) * effect.maxHealthMod * effect.healthRegenMod 
		//	* effect.maxManaMod * effect.manaRegenMod * effect.damageMod * effect.attackTimeMod * effect.knockbackMod * effect.speedMod * effect.jumpSpeedMod;

	}
}