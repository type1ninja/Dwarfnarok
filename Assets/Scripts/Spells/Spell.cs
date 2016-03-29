using UnityEngine;
using System.Collections;

//These are the other properties spell has, aside from the direct effects
public class Spell {

	static float BASIC_MANA_COST = 15f;

	public SpellEffect effect;

	public bool targetsEnemies = true;
	public bool isSelfSpell = false;
	public bool AoE = false;

	public float manaCost;
	public float attackTime = .75f;
	public float projectileSpeed = 2500f;
	public bool affectedByGravity = true;
	public float radius = 1;

	public Spell() {
		effect = new SpellEffect ();

		//TODO - MAKE MANA COST MAKE SENSE
		//Allow each spell only to modify two stats
		//For friendlies: two positives == most expensive, one positive == medium, one positive one negative == cheapest
		//For enemies: two negatives == most expensive, one negative == medium one negative one positive == cheapest
		manaCost = BASIC_MANA_COST; 
	}
}