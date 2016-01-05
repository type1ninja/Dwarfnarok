using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

	public static int NUM_OF_WEPS = 8;

	HeldWeapon wep;

	void Start() {
		wep = new Weapon (WeaponType.AXE);
}