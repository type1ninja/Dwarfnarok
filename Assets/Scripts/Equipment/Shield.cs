using UnityEngine;
using System.Collections;

public class Shield : Weapon {

	public static float GLOBAL_SHIELD_PASSIVE_ARMOR_MOD = 1.15f;
	public static float GLOBAL_SHIELD_ACTIVE_ARMOR_MOD = 1.5f;

	public static float ACTIVE_SHIELD_SPEED_MODIFIER = 0.5f;

	//Just for the constructor
	public static float SHIELD_HANDLE_LENGTH = 0f;
	public static float SHIELD_HEAD_SIZE = 0f;

	public Shield() : base(WeaponType.SHIELD, SHIELD_HANDLE_LENGTH, SHIELD_HEAD_SIZE) {
		//The constructor for a shield calls the base constructor using all zeros
		//as shields are only used for blocking
	}
}