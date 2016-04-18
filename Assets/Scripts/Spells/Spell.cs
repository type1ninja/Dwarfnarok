using UnityEngine;
using System.Collections;

//These are the other properties spell has, aside from the direct effects
public class Spell {

	static float BASIC_MANA_COST = 10f;
	static float GRAVITY_COST_MODIFIER = 0.90f;

	public SpellEffect effect;

	public bool targetsEnemies = true;
	public bool isSelfSpell = false;
	public bool AoE = false;

	public float manaCost;
	public float attackTime = 0.75f;
	public float projectileSpeed = 2500f;
	public bool affectedByGravity = true;
	public float radius = 1;
	public float lifetime = 4f;
	public float size = 1f;

	public Color col = new Color(1, 1, 1);

	public Spell() {
		effect = new SpellEffect ();
		CalculateCost ();
	}

	public void CalculateCost() {
		//Base cost
		manaCost = BASIC_MANA_COST;

		//When targeting enemies: negative effects increase cost, positive effects decrease it 
		if (targetsEnemies) {

			//Stat modifiers: since negative effects help the player, we need to inverse all of these 
			//positive effects
			manaCost *= (1 / effect.maxHealthMod) * (1 / effect.healthRegenMod) 
				* (1 / effect.damageReductionMod) * (1 / effect.maxManaMod) 
				* (1 / effect.manaRegenMod) * (1 / effect.damageMod) 
				* (1 / effect.attackTimeMod) * (1 / effect.knockbackMod) 
				* (1 / effect.speedMod) * (1 / effect.jumpSpeedMod); 

			//Instant effects: since more of damage helps the player, and it comes as an
			//absolute value, we add it so the negative minimum is at 1/3 the max, we just divide it so 
			//it scales to a .5-1.5 scale.
			//Knockback is helpful to the player no matter which direction is goes, so calculate that
			//in a similar way with absolute value
			manaCost *= ((effect.instantDamage + 10) / 10) * (Mathf.Abs (effect.instantKnockback / 24) + 1);
		} 
		//When targeting friendlies: positive effects increase cost, negative effects decrease it
		else if (!targetsEnemies) {

			//Stat modifiers: since postive effects help the player, we just multiply
			manaCost *= effect.maxHealthMod * effect.healthRegenMod 
				* effect.damageReductionMod * effect.maxManaMod * effect.manaRegenMod 
				* effect.damageMod * effect.attackTimeMod * effect.knockbackMod 
				* effect.speedMod * effect.jumpSpeedMod; 

			//Instant effects: since smaller (negative) values of damage helps the player, and these come 
			//as absolute values, we subtract it so the positive maximum is a negative number and 1/3
			//the magnitude of the minimum. Calculate knockback as above
			manaCost *= ((effect.instantDamage - 10) / -10) * (Mathf.Abs (effect.instantKnockback / 24) + 1);
		}

		//Stuff that’s the same for friendlies *and* enemies

		if (AoE){
			//For AoE radius, multiply by radius divided by 4
			manaCost *= radius;
		}
		//For duration, divide by 3 (the default) and multiply... if:
		//If there are no duration effects, don't bother
		if (effect.maxHealthMod == 1 && effect.healthRegenMod == 1 && effect.damageReductionMod == 1
			&& effect.maxManaMod == 1 && effect.manaRegenMod == 1 && effect.damageMod == 1 && effect.attackTimeMod == 1
			&& effect.knockbackMod == 1 && effect.speedMod == 1 && effect.jumpSpeedMod == 1) {
			//Do nothing
		} //If there is an instant effect AND some duration effect, then allow cost to increase from duration but not decrease
		//That way you can't just add, say +maxhealth, and then set the duration to zero for a total of zero cost
		else if (effect.instantDamage != 0 || effect.instantKnockback != 0) {
			if (effect.duration > 3) {
				manaCost *= (effect.duration / 3);
			}
		} //Otherwise there are only duration effects, then scale as normal
		else {
			manaCost *= (effect.duration / 3);
		}

		//Stuff only for projectiles
		if (!isSelfSpell) { 
			//Projectile speed is weird. Between 1000 and the max, the player is either reducing the cost by 
			//making it slower or increasing it by making it faster. Below 1000, though, there’s a good chance 
			//the player is doing it on purpose (bombs, landmines), so that just stays default (multiplier of 1)
			if (projectileSpeed > 1000) {
				manaCost *= projectileSpeed / 2500;
			} else if (projectileSpeed <= 1000) {
				manaCost *= 1; //Do nothing
			}

			//Being affected by gravity decreases the effective range, so make that reduce cost (but only slightly)
			if (affectedByGravity) {
				manaCost *= GRAVITY_COST_MODIFIER; //Maybe .85 for now?
			}

			//Lifetime cost--just multiply by the cost. A 1 sec range isn't unreasonable
			manaCost *= lifetime;
			//Size--same thing
			manaCost *= size;
		}
	}
}