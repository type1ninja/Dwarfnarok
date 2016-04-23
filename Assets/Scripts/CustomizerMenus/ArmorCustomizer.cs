using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArmorCustomizer : MonoBehaviour {

	Armor armor;

	PlayerWepControl wepControl;
	PlayerSpellControl spellControl;
	PlayerMove mover;
	SimpleSmoothMouseLook mouseLook;

	Renderer playerRenderer;

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

	Slider redSlider;
	Slider greenSlider;
	Slider blueSlider;

	Image colorImage;

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
		Transform sliders = transform.Find ("Sliders");

		armor = GameObject.Find ("Player").GetComponent<CharacterStats> ().armor;

		wepControl = GameObject.Find ("Player").GetComponent<PlayerWepControl> ();
		spellControl = GameObject.Find ("Player").GetComponent<PlayerSpellControl> ();
		mover = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		mouseLook = GameObject.Find ("Player").GetComponentInChildren<SimpleSmoothMouseLook> ();

		playerRenderer = GameObject.Find ("Player").transform.Find ("Graphics").GetComponent<Renderer> ();

		maxHealthSlider = sliders.Find ("MaxHealthSlider").GetComponent<Slider> ();
		healthRegenSlider = sliders.Find ("HealthRegenSlider").GetComponent<Slider> ();
		damageReductionSlider = sliders.Find ("DamageReductionSlider").GetComponent<Slider> ();
		maxManaSlider = sliders.Find ("MaxManaSlider").GetComponent<Slider> ();
		manaRegenSlider = sliders.Find ("ManaRegenSlider").GetComponent<Slider> ();
		damageSlider = sliders.Find ("DamageSlider").GetComponent<Slider> ();
		attackTimeSlider = sliders.Find ("AttackTimeSlider").GetComponent<Slider> ();
		knockbackSlider = sliders.Find ("KnockbackSlider").GetComponent<Slider> ();
		speedSlider = sliders.Find ("SpeedSlider").GetComponent<Slider> ();
		jumpSpeedSlider = sliders.Find ("JumpSpeedSlider").GetComponent<Slider> ();

		redSlider = transform.Find ("ColorCustomizers").Find ("RedSlider").GetComponent<Slider> ();
		greenSlider = transform.Find ("ColorCustomizers").Find ("GreenSlider").GetComponent<Slider> ();
		blueSlider = transform.Find ("ColorCustomizers").Find ("BlueSlider").GetComponent<Slider> ();

		colorImage = transform.Find ("ColorCustomizers").Find ("ColorImage").GetComponent<Image> ();

		pointsLeftTxt = transform.Find ("PointsLeft").GetComponent<Text>();
	}

	public void Reset() {
		maxHealthSlider.value = 1;
		healthRegenSlider.value = 1;
		damageReductionSlider.value = 0;
		maxManaSlider.value = 1;
		manaRegenSlider.value = 1;
		damageSlider.value = 1;
		attackTimeSlider.value = 1;
		knockbackSlider.value = 1;
		speedSlider.value = 1;
		jumpSpeedSlider.value = 1;

		redSlider.value = .5f;
		greenSlider.value = .5f;
		blueSlider.value = .5f;
	}
	
	void Update () {
		//TODO - allow the interaction button to close this as well
		if (Input.GetButtonDown ("Cancel") || Input.GetButtonDown ("Interact")) {
			mover.canMove = true;
			mouseLook.shouldLook = true;
			wepControl.canSwing = true;
			spellControl.canFire = true;
			gameObject.SetActive (false);
		}

		//If the current values are less than the stat limit, update them and record their values
		//damageReductionMod is different, it scales from -.3 to .3, so we have to transform that to a .5 to 1.5 scale
		if ((maxHealthSlider.value + healthRegenSlider.value + 
			((damageReductionSlider.value + .6f) / .6f) + 
			maxManaSlider.value + manaRegenSlider.value + damageSlider.value + 
			attackTimeSlider.value + knockbackSlider.value + speedSlider.value + jumpSpeedSlider.value) 
			<= STAT_SUM_LIMIT) {

			armor.maxHealthMod = maxHealthSlider.value;
			armor.healthRegenMod = healthRegenSlider.value;
			armor.damageReductionMod = damageReductionSlider.value;
			armor.maxManaMod = maxManaSlider.value;
			armor.manaRegenMod = manaRegenSlider.value;
			armor.damageMod = damageSlider.value;
			//The attackTimeMod thing is also slightly different
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

		pointsLeftTxt.text = "Points Left: " + (STAT_SUM_LIMIT - (maxHealthSlider.value + healthRegenSlider.value + 
			((damageReductionSlider.value + .6f) / .6f) + 
			maxManaSlider.value + manaRegenSlider.value + damageSlider.value + 
			attackTimeSlider.value + knockbackSlider.value + speedSlider.value + jumpSpeedSlider.value)).ToString ("F2");

		//Color stuff
		playerRenderer.material.color = new Color (redSlider.value, greenSlider.value, blueSlider.value);
		colorImage.color = new Color (redSlider.value, greenSlider.value, blueSlider.value);
	}
}