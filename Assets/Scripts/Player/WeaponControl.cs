using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

	public static int NUM_OF_WEPS = 8;

	Weapon[] weps = new Weapon[NUM_OF_WEPS];
	Weapon primaryWep;
	Weapon secondaryWep;

	void Start() {
		for (int i = 0; i < weps.Length; i++) {
			//Initialize every weapon as a stock axe
			weps[i] = new Weapon(WeaponType.AXE);
		}
		//TODO - WEAPON SELECTION DURING GAME
		primaryWep = weps [0];
		secondaryWep = weps [1];
	}
}