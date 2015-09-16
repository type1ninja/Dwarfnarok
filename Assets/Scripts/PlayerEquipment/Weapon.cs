using UnityEngine;
using System.Collections;

public class Weapon {
	//Global modifiers for certain weapons
	//These are always applied on top of whatever mods the specific weapon has
	//So "1.0" represents the damage of a stock tool, so "1.0" means different
	//things for a sword, axe, and hammer
	public static float GLOBAL_AXE_DAMAGE_MOD = 1.0f;
	public static float GLOBAL_AXE_KNOCKBACK_MOD = 1.0f;
	public static float GLOBAL_AXE_ATTACK_TIME_MOD = 1.0f;
	public static float GLOBAL_SWORD_DAMAGE_MOD = 0.75f;
	public static float GLOBAL_SWORD_KNOCKBACK_MOD = 0.75f;
	public static float GLOBAL_SWORD_ATTACK_TIME_MOD = 0.75f;
	public static float GLOBAL_HAMMER_DAMAGE_MOD = 1.5f;
	public static float GLOBAL_HAMMER_KNOCKBACK_KMOD = 1.5f;
	public static float GLOBAL_HAMMER_ATTACK_TIME_MOD = 1.5f;

	public WeaponType type;

	public float handleLength;
	public float headSize;
	public float damageMod;
	public float knockbackMod;
	public float attackTime;

	public Weapon(WeaponType newType, float newHandleLength = 1.0f, float newHeadSize = 1.0f) {
		//Defaults represent stock axe stats

		if (newType == WeaponType.SHIELD || newType == WeaponType.TORCH) {
			Debug.LogWarning("You should probably be initializing this object as a shield or torch, not as a generic weapon.");
		}

		type = newType;
		handleLength = newHandleLength;
		headSize = newHeadSize; 
		//TODO - balance these?
		damageMod = headSize * handleLength;
		knockbackMod = headSize * handleLength;
		attackTime = headSize * handleLength; 
	}
}