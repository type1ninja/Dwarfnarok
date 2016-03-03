using UnityEngine;
using System.Collections;

//The effects a spell has on someone
public class SpellEffect {
	//Effects that last the duration

	public float maxHealthMod = 1f;
	public float healthRegenMod = 1f;
	public float damageResistMod = 1f;
	public float maxManaMod = 1f;
	public float manaRegenMod = 1f;
	public float damageMod = 1f;
	public float attackTimeMod = 1f;
	public float knockbackMod = 1f;
	public float speedMod = 1f;
	public float jumpSpeedMod = 1f;

	float duration = 3f;

	public void DecrementTime(float decrement) {
		duration -= decrement;
	}

	public bool IsDurationOver() {
		if (duration <= 0) {
			return true;
		} else {
			return false;
		}
	}
}