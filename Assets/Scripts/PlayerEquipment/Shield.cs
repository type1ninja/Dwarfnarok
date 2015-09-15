using UnityEngine;
using System.Collections;

public class Shield : Weapon {

	public static float GLOBAL_SHIELD_PASSIVE_ARMOR_BUFF = 1.15f;
	public static float GLOBAL_SHIELD_ACTIVE_ARMOR_BUFF = 1.5f;

	public Shield() : base(WeaponType.SHIELD, 0, 0, 0, 0, 0) {
		//The constructor for a shield calls the base constructor using all zeros
		//as shields are only used for blocking
	}
}