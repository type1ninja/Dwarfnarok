﻿using UnityEngine;
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
	public static float GLOBAL_HAMMER_KNOCKBACK_MOD = 1.5f;
	public static float GLOBAL_HAMMER_ATTACK_TIME_MOD = 1.5f;

	public WeaponType type;

	public float handleLength;
	public float headSize;
	public float damageMod;
	public float knockbackMod;
	public float attackTime;

	//Defaults in constructor represent stock axe stats
	public Weapon(WeaponType newType = WeaponType.AXE, float newHandleLength = 1.0f, float newHeadSize = 1.0f) {
		UpdateStats (newType, newHandleLength, newHeadSize);
	}

	public void UpdateStats(WeaponType newType = WeaponType.AXE, float newHandleLength = 1.0f, float newHeadSize = 1.0f) {
		type = newType;
		handleLength = newHandleLength;
		headSize = newHeadSize; 

		//TODO - balance these? 
		//DPS is identical on all weapons, but bigger weapons also get larger knockback and reach, so...
		damageMod = headSize * handleLength;
		knockbackMod = headSize * handleLength;
		attackTime = headSize * handleLength;

		switch (type) {
		case WeaponType.AXE:
			damageMod *= GLOBAL_AXE_DAMAGE_MOD;
			knockbackMod *= GLOBAL_AXE_KNOCKBACK_MOD;
			attackTime *= GLOBAL_AXE_ATTACK_TIME_MOD;
			break;
		case WeaponType.HAMMER:
			damageMod *= GLOBAL_HAMMER_DAMAGE_MOD;
			knockbackMod *= GLOBAL_HAMMER_KNOCKBACK_MOD;
			attackTime *= GLOBAL_HAMMER_ATTACK_TIME_MOD;
			break;
		//Other weapons default to sword stats
		default:
			damageMod *= GLOBAL_SWORD_DAMAGE_MOD;
			knockbackMod *= GLOBAL_SWORD_KNOCKBACK_MOD;
			attackTime *= GLOBAL_SWORD_ATTACK_TIME_MOD;
			break;
		}
	}
}