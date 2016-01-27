using UnityEngine;
using System.Collections;

//TODO - ACCOUNT FOR HANDED-NESS
public abstract class CharacterWepControl : MonoBehaviour {

	CharacterStats stats;
	Transform weaponTransform;

	//TODO - do dual wield + multiple weapons. For now, though, single-weapon single-wield is fine. 
	public Weapon wep;

	//Maximum time spent swinging a weapon
	float maxAttackTime;
	//Decremented by the current fixedDeltaTime each FixedUpdate while the player is swinging. Reset once it reaches 0
	float currentAttackTime;
	public bool isSwinging = false;

	//TODO - MAKE ANIMATIONS FOR SLOW WEPS HAVE A SET LENGTH + WAIT PERIOD AFTER SWINGING - FAST WEPS GET FAST ANIMATIONS
	float totalDegrees = 65f;
	float degreesPerSec;
	Vector3 currentSwingRot;

	Vector3 startSwingRot = new Vector3 (70, 30, 0);
	Vector3 idleRot = new Vector3(20, 60, 0);
	Vector3 swingPos = new Vector3(-0.038f, -.059f, .534f);
	Vector3 idlePos = new Vector3(-0.038f, -.629f, .534f);
	
	void Start() {
		stats = GetComponent<CharacterStats> ();
		weaponTransform = transform.Find ("CharacterHead").Find ("RightWep");

		wep = new Weapon ();

		maxAttackTime = stats.GetAttackTime() * wep.attackTime;
		currentAttackTime = maxAttackTime;
		//TODO - GET VARIABLES FOR THE DEFAULT POSITION SEPARATE FROM SWINGING YOUR WEP
		currentSwingRot = idleRot;
		weaponTransform.localPosition = idlePos;
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

			if (currentAttackTime <= 0) {
				currentAttackTime = maxAttackTime;
				isSwinging = false;
				currentSwingRot = idleRot;
				weaponTransform.localPosition = idlePos;
				//TODO - MAKE AN IDLE POSITION/ANIMATION 
			}
		}

		weaponTransform.localRotation = Quaternion.Euler (currentSwingRot);
	}

	//TODO - MAYBE HAVE EACH SWING STORE A LIST OF HIT OBJECTS NOT TO BE HIT AGAIN DURING THE DURATION OF THE SWING

	protected void Swing() {
		//Only allow swinging if the current swing is done
		if (!isSwinging) {
			isSwinging = true;
			currentSwingRot = startSwingRot;
			weaponTransform.localPosition = swingPos;
		}
	}

	public float GetDamage() {
		return (stats.GetDamage() * wep.damageMod);
	}

	public float GetKnockback() {
		return (stats.knockback * wep.knockbackMod);
	}

	public float GetMaxSwingTime() {
		return maxAttackTime;
	}

	protected abstract bool CheckForSwing();
}