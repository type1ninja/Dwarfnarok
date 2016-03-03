using UnityEngine;
using System.Collections;

//These are the other properties spell has, aside from the direct effects
public class Spell {

	static float BASIC_MANA_COST = 10f;

	SpellEffect effect;

	//TODO - actually use these :P
	bool targetsEnemies = true;
	float AOERadius = 0f;
	bool isAOE = false;
	float manaCost;

	public Spell() {
		manaCost = BASIC_MANA_COST;
		if (AOERadius == 0) {
			isAOE = false;
		} else {
			isAOE = true;
		}
	}
}