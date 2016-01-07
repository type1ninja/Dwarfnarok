using UnityEngine;
using System.Collections;

//TODO - ACCOUNT FOR HANDED-NESS
public class WeaponControl : MonoBehaviour {

	PlayerStats pstats;
	Transform weaponTransform;

	//TODO - do dual wield + multiple weapons. For now, though, single-weapon single-wield is fine. 
	Weapon wep;

	//Maximum time spent swinging a weapon
	float maxAttackTime;
	//Decremented by the current fixedDeltaTime each FixedUpdate while the player is swinging. Reset once it reaches 0
	float currentAttackTime;
	bool isSwinging = false;

	//TODO - Rotation variables
	float totalDegrees = 65f;
	float degreesPerSec;
	Vector3 startSwingRot;
	Vector3 currentSwingRot;
	
	void Start() {
		pstats = GetComponent<PlayerStats> ();
		weaponTransform = transform.Find ("PlayerCam").Find ("RightWep");

		wep = new Weapon ();

		maxAttackTime = pstats.attackTime * wep.attackTime;
		currentAttackTime = maxAttackTime;
		//TODO - GET VARIABLES FOR THE DEFAULT POSITION
		startSwingRot = new Vector3 (70, 30, 0);
		currentSwingRot = startSwingRot;
	}

	void FixedUpdate() {

		maxAttackTime = pstats.attackTime * wep.attackTime;
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

		if (Input.GetAxis ("PrimaryFire") != 0) {
			Swing ();
		}
	}

	public void Swing() {
		//Only allow swinging if the current swing is done
		if (!isSwinging) {
			isSwinging = true;
			weaponTransform.localRotation = Quaternion.Euler (startSwingRot);
		}
	}
}