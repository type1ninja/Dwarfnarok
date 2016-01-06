using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

	PlayerStats pstats;

	//TODO - do dual wield + multiple weapons. For now, though, single-wield is fine. 
	Weapon wep;

	//Maximum time spent swinging a weapon
	float maxAttackTime;
	//Decremented by the current fixedDeltaTime each FixedUpdate while the player is swinging. Reset once it reaches 0
	float currentAttackTime;
	bool isSwinging = false;

	//TODO - Rotation variables
	float totalDegrees = 60f;
	
	void Start() {
		pstats = GetComponentInParent<PlayerStats> ();

		wep = new Weapon ();

		maxAttackTime = pstats.attackTime * wep.attackTime;
		currentAttackTime = maxAttackTime;
	}

	void FixedUpdate() {

		maxAttackTime = pstats.attackTime * wep.attackTime;

		if (isSwinging) {
			currentAttackTime -= Time.fixedDeltaTime;

			if (currentAttackTime <= 0) {
				currentAttackTime = maxAttackTime;
				isSwinging = false;
			}
		}

		if (Input.GetAxis ("PrimaryFire") != 0) {
			Swing ();
		}
	}

	public void Swing() {
		isSwinging = true;
	}
}