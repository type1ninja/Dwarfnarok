using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterEffects : MonoBehaviour {
	CharacterHealthMana healthmana;

	List<SpellEffect> effects = new List<SpellEffect>();

	void Start() {
		healthmana = GetComponent<CharacterHealthMana> ();
	}

	//Update timers
	void FixedUpdate() {
		for (int i = 0; i < effects.Count; i++) {
			effects[i].DecrementTime ();

			if (effects[i].IsDurationOver ()) {
				effects.RemoveAt (i);
			}
		}
	}

	public void AddEffect(SpellEffect newEffect) {
		//If you already have the effect, just refresh the timer
		bool hasEffect = false;
		for (int i = 0; i < effects.Count; i++) {
			if (effects [i].Equals (newEffect)) {
				hasEffect = true;
				effects [i].SetDuration (newEffect.duration);
			}
		}
		//If not, add the effect
		if (!hasEffect) {
			effects.Add (newEffect);
		} 

		//Do damage regardless
		healthmana.ModHealth (-1 * newEffect.instantDamage);
		//Knockback is applied within the "projectile spell" code
	}

	//All the methods for getting total stat mods
	public float GetMaxHealthMod() {
		float mod = 1f;

		for (int i = 0; i < effects.Count; i++) {
			mod *= effects[i].maxHealthMod;
		}
		
		return mod;
	}
	public float GetHealthRegenMod() {
		float mod = 1f;

		for (int i = 0; i < effects.Count; i++) {
			mod *= effects[i].healthRegenMod;
		}

		return mod;
	}
	public float GetDamageReductionMod() {
		float mod = 1f;

		for (int i = 0; i < effects.Count; i++) {
			mod *= effects[i].damageReductionMod;
		}
		
		return mod;
	}
	public float GetMaxManaMod() {
		float mod = 1f;
		
		for (int i = 0; i < effects.Count; i++) {
			mod *= effects[i].maxManaMod;
		}
		
		return mod;
	}
	public float GetManaRegenMod() {
		float mod = 1f;
		
		for (int i = 0; i < effects.Count; i++) {
			mod *= effects[i].manaRegenMod;
		}
		
		return mod;
	}
	public float GetDamageMod() {
		float mod = 1f;
		
		for (int i = 0; i < effects.Count; i++) {
			mod *= effects[i].damageMod;
		}
		
		return mod;
	}
	public float GetAttackTimeMod() {
		float mod = 1f;
		
		for (int i = 0; i < effects.Count; i++) {
			mod *= effects[i].attackTimeMod;
		}
		
		return mod;
	}
	public float GetKnockbackMod() {
		float mod = 1f;
		
		for (int i = 0; i < effects.Count; i++) {
			
		}
		
		return mod;
	}
	public float GetSpeedMod() {
		float mod = 1f;
		
		for (int i = 0; i < effects.Count; i++) {
			mod *= effects[i].speedMod;
		}
		
		return mod;
	}
	public float GetJumpSpeedMod() {
		float mod = 1f;
		
		for (int i = 0; i < effects.Count; i++) {
			mod *= effects[i].jumpSpeedMod;
		}
		
		return mod;
	}
}