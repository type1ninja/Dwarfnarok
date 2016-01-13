﻿using UnityEngine;
using System.Collections;

//TODO - ACCOUNT FOR HANDED-NESS
public abstract class CharacterWepControl : MonoBehaviour {

	CharacterStats stats;
	Transform weaponTransform;

	//TODO - do dual wield + multiple weapons. For now, though, single-weapon single-wield is fine. 
	Weapon wep;

	//Maximum time spent swinging a weapon
	float maxAttackTime;
	//Decremented by the current fixedDeltaTime each FixedUpdate while the player is swinging. Reset once it reaches 0
	float currentAttackTime;
	public bool isSwinging = false;
	
	float totalDegrees = 65f;
	float degreesPerSec;
	Vector3 startSwingRot = new Vector3 (70, 30, 0);
	Vector3 currentSwingRot;
	
	void Start() {
		stats = GetComponent<CharacterStats> ();
		weaponTransform = transform.Find ("CharacterHead").Find ("RightWep");

		wep = new Weapon ();

		maxAttackTime = stats.GetAttackTime() * wep.attackTime;
		currentAttackTime = maxAttackTime;
		//TODO - GET VARIABLES FOR THE DEFAULT POSITION
		currentSwingRot = startSwingRot;
	}

	void FixedUpdate() {
		if (CheckForSwing ()) {
			Swing ();
		}

		maxAttackTime = stats.GetAttackTime() * wep.attackTime;
		//Multiply by -1 to make it rotate the right way
		degreesPerSec = -1 * totalDegrees / maxAttackTime;

		if (isSwinging) {
			currentAttackTime -= Time.fixedDeltaTime;
			currentSwingRot.y += degreesPerSec * Time.fixedDeltaTime;
			weaponTransform.localRotation = Quaternion.Euler (currentSwingRot);

			if (currentAttackTime <= 0) {
				currentAttackTime = maxAttackTime;
				isSwinging = false;
				currentSwingRot = startSwingRot;
				//TODO - MAKE AN IDLE POSITION/ANIMATION 
				weaponTransform.localRotation = Quaternion.Euler (startSwingRot);
			}
		}
	}

	protected void Swing() {
		//Only allow swinging if the current swing is done
		if (!isSwinging) {
			isSwinging = true;
			weaponTransform.localRotation = Quaternion.Euler (startSwingRot);
		}
	}

	public float GetDamage() {
		return (stats.GetDamage() * wep.damageMod);
	}

	protected abstract bool CheckForSwing();
}