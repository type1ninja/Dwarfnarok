using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float handleLength = 1.0f;
	public float headSize = 1.0f;
	public float dmgMod = 1.0f;
	public float knockbackMod = 1.0f;
	//Armor mods are for shields
	public float passiveArmorMod = 0.0f;
	public float blockingArmorMod = 0.0f;
	public float maxAttackTime = 1.0f;
	//Default to sword, but this should be set EVERY TIME
	public WeaponType type = WeaponType.SWORD;

	float currentAttackTime;
	bool isAttacking = false;

	void Start() {
		currentAttackTime = maxAttackTime;
	}

	void FixedUpdate() {
		if (isAttacking) {
			currentAttackTime -= Time.fixedDeltaTime;
			if (currentAttackTime <= 0) {
				isAttacking = false;
				currentAttackTime = maxAttackTime;
			}
		}
	}
}