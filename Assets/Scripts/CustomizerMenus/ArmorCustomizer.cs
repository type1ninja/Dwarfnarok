using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArmorCustomizer : MonoBehaviour {

	Armor armor;

	PlayerWepControl wepControl;
	PlayerMove mover;
	SimpleSmoothMouseLook mouseLook;

	static float STAT_SUM_LIMIT = 10;
	
	//TODO - ALL THE SLIDERS
	Slider maxHealthSlider;
	Slider healthRegenSlider;
	Slider damageReductionSlider;
	Slider maxManaSlider;
	Slider manaRegenSlider;
	Slider damageSlider;
	Slider attackTimeSlider;
	Slider knockbackSlider;
	Slider speedSlider;
	Slider jumpSpeedSlider;

	Text pointsLeftTxt;

	float maxHealthLastValue;
	float healthRegenLastValue;
	float damageReductionLastValue;
	float maxManaLastValue;
	float manaRegenLastValue;
	float damageLastValue;
	float attackTimeLastValue;
	float knockbackLastValue;
	float speedLastValue;
	float jumpSpeedLastValue;

	void Start() {
		armor = GameObject.Find ("Player").GetComponent<CharacterStats> ().armor;

		wepControl = GameObject.Find ("Player").GetComponent<PlayerWepControl> ();
		mover = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		mouseLook = GameObject.Find ("Player").GetComponentInChildren<SimpleSmoothMouseLook> ();
		
		//TODO - GET ALL THE SLIDERS
		maxHealthSlider = transform.Find ("Sliders").Find ("MaxHealthSlider").GetComponent<Slider> ();
		healthRegenSlider = transform.Find ("Sliders").Find ("HealthRegenSlider").GetComponent<Slider> ();
		damageReductionSlider = transform.Find ("Sliders").Find ("DamageReductionSlider").GetComponent<Slider> ();
		maxManaSlider = transform.Find ("Sliders").Find ("MaxManaSlider").GetComponent<Slider> ();
		manaRegenSlider = transform.Find ("Sliders").Find ("ManaRegenSlider").GetComponent<Slider> ();
		damageSlider = transform.Find ("Sliders").Find ("DamageSlider").GetComponent<Slider> ();
		attackTimeSlider = transform.Find ("Sliders").Find ("AttackTimeSlider").GetComponent<Slider> ();
		knockbackSlider = transform.Find ("Sliders").Find ("KnockbackSlider").GetComponent<Slider> ();
		speedSlider = transform.Find ("Sliders").Find ("SpeedSlider").GetComponent<Slider> ();
		jumpSpeedSlider = transform.Find ("Sliders").Find ("JumpSpeedSlider").GetComponent<Slider> ();

		pointsLeftTxt = transform.Find ("PointsLeft").GetComponent<Text>();
	}
	
	void Update () {
		//TODO - allow the interaction button to close this as well
		if (Input.GetButton ("Cancel")) {
			mover.canMove = true;
			mouseLook.shouldLook = true;
			wepControl.canSwing = true;
			gameObject.SetActive (false);
		}

		//TODO - FIX POINTSLEFT INACCURACIES
		pointsLeftTxt.text = "Points Left: " + (STAT_SUM_LIMIT - (maxHealthSlider.value + healthRegenSlider.value + 
		    damageReductionSlider.value + maxManaSlider.value + manaRegenSlider.value + damageSlider.value + 
		    attackTimeSlider.value + knockbackSlider.value + speedSlider.value + jumpSpeedSlider.value)).ToString ("F2");

		//If the current values are less than the stat limit, update them and record their values
		if ((maxHealthSlider.value + healthRegenSlider.value + damageReductionSlider.value + 
			maxManaSlider.value + manaRegenSlider.value + damageSlider.value + 
			attackTimeSlider.value + knockbackSlider.value + speedSlider.value + jumpSpeedSlider.value) 
			<= STAT_SUM_LIMIT) {

			armor.maxHealthMod = maxHealthSlider.value;
			armor.healthRegenMod = healthRegenSlider.value;
			armor.damageReductionMod = damageReductionSlider.value;
			armor.maxManaMod = maxManaSlider.value;
			armor.manaRegenMod = manaRegenSlider.value;
			armor.damageMod = damageSlider.value;
			//The attackTimeMod thing is slightly different:
			//It's the inverse, because players should be thinking in terms of speed, 
			//but the variable itself is time. So we inverse it. 
			armor.attackTimeMod = 1 / attackTimeSlider.value;
			armor.knockbackMod = knockbackSlider.value;
			armor.speedMod = speedSlider.value;
			armor.jumpSpeedMod = jumpSpeedSlider.value;

			maxHealthLastValue = maxHealthSlider.value;
			healthRegenLastValue = healthRegenSlider.value;
			damageReductionLastValue = damageReductionSlider.value;
			maxManaLastValue = maxManaSlider.value;
			manaRegenLastValue = manaRegenSlider.value;
			damageLastValue = damageSlider.value;
			attackTimeLastValue = attackTimeSlider.value;
			knockbackLastValue = knockbackSlider.value;
			speedLastValue = speedSlider.value;
			jumpSpeedLastValue = jumpSpeedSlider.value;
		
		//If the current values are GREATER than the stat limit, set the sliders and values 
		//to whatever they were before they were too big
		} else {

			armor.maxHealthMod = maxHealthLastValue;
			armor.healthRegenMod = healthRegenLastValue;
			armor.damageReductionMod = damageReductionLastValue;
			armor.maxManaMod = maxManaLastValue;
			armor.manaRegenMod = manaRegenLastValue;
			armor.damageMod = damageLastValue;
			//The attackTimeMod thing is slightly different:
			//It's the inverse, because players should be thinking in terms of speed, 
			//but the variable itself is time. So we inverse it. 
			armor.attackTimeMod = 1 / attackTimeLastValue;
			armor.knockbackMod = knockbackLastValue;
			armor.speedMod = speedLastValue;
			armor.jumpSpeedMod = jumpSpeedLastValue;

			maxHealthSlider.value = maxHealthLastValue;
			healthRegenSlider.value = healthRegenLastValue;
			damageReductionSlider.value = damageReductionLastValue;
			maxManaSlider.value = maxManaLastValue;
			manaRegenSlider.value = manaRegenLastValue;
			damageSlider.value = damageLastValue;
			attackTimeSlider.value = attackTimeLastValue;
			knockbackSlider.value = knockbackLastValue;
			speedSlider.value = speedLastValue;
			jumpSpeedSlider.value = jumpSpeedLastValue;
		}
	}
}