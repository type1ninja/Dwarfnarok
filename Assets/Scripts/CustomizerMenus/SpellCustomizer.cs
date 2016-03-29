using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpellCustomizer : MonoBehaviour {

	Spell spell;

	PlayerWepControl wepControl;
	PlayerSpellControl spellControl;
	PlayerMove mover;
	SimpleSmoothMouseLook mouseLook;


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
	Slider instantDamageSlider;
	Slider instantKnockbackSlider; 
	Slider projectileSpeedSlider;
	Slider radiusSlider;
	Slider durationSlider;

	Toggle targetToggle;
	Toggle self;
	Toggle AoE;
	Toggle affectedByGravity;

	Text durationLabel;
	Text radiusLabel;

	void Start () {
		spell = GameObject.Find ("Player").GetComponent<CharacterSpellControl> ().spell;

		wepControl = GameObject.Find ("Player").GetComponent<PlayerWepControl> ();
		spellControl = GameObject.Find ("Player").GetComponent<PlayerSpellControl> ();
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
		instantDamageSlider = transform.Find ("Sliders").Find ("InstantDamageSlider").GetComponent<Slider> ();
		instantKnockbackSlider = transform.Find ("Sliders").Find ("InstantKnockbackSlider").GetComponent<Slider> ();
		projectileSpeedSlider = transform.Find ("Sliders").Find ("ProjectileSpeedSlider").GetComponent<Slider>();
		radiusSlider = transform.Find ("Sliders").Find ("RadiusSlider").GetComponent<Slider> ();
		durationSlider = transform.Find ("Sliders").Find ("DurationSlider").GetComponent<Slider> ();

		targetToggle = transform.Find ("Checkboxes").Find ("TargetsEnemies").GetComponent<Toggle> ();
		self = transform.Find ("Checkboxes").Find ("Self").GetComponent<Toggle> ();
		affectedByGravity = transform.Find ("Checkboxes").Find ("Gravity").GetComponent<Toggle> ();
		AoE = transform.Find ("Checkboxes").Find ("AoE").GetComponent<Toggle> ();

		radiusLabel = transform.Find ("Labels").Find ("RadiusLabel").GetComponent<Text> ();
		durationLabel = transform.Find ("Labels").Find ("DurationLabel").GetComponent<Text> ();
	}

	public void Reset() {
		maxHealthSlider.value = 1;
		healthRegenSlider.value = 1;
		damageReductionSlider.value = 1;
		maxManaSlider.value = 1;
		manaRegenSlider.value = 1;
		damageSlider.value = 1;
		attackTimeSlider.value = 1;
		knockbackSlider.value = 1;
		speedSlider.value = 1;
		jumpSpeedSlider.value = 1;
		instantDamageSlider.value = 0;
		instantKnockbackSlider.value = 0;
		projectileSpeedSlider.value = 2500;
		radiusSlider.value = 1;
		durationSlider.value = 3;

		targetToggle.isOn = true;
		self.isOn = false;
		AoE.isOn = false;
		affectedByGravity.isOn = true;
	}
	
	//TODO - ALLOW CUSTOMIZATION OF INSTANT EFFECTS, AOE, FRIENDLY/ENEMY TARGETING, SHOW MANA COST
	void Update () {
		//TODO - allow the interaction button to close this as well
		if (Input.GetButton ("Cancel")) {
			mover.canMove = true;
			mouseLook.shouldLook = true;
			wepControl.canSwing = true;
			spellControl.canFire = true;
			gameObject.SetActive (false);
		}

		//TODO - limit what players can change, also add stuff like "targets friendles" and "is AoE"
		spell.effect.maxHealthMod = maxHealthSlider.value;
		spell.effect.healthRegenMod = healthRegenSlider.value;
		spell.effect.damageReductionMod = damageReductionSlider.value;
		spell.effect.maxManaMod = maxManaSlider.value;
		spell.effect.manaRegenMod = manaRegenSlider.value;
		spell.effect.damageMod = damageSlider.value;
		//The attackTimeMod thing is slightly different:
		//It's the inverse, because players should be thinking in terms of speed, 
		//but the variable itself is time. So we inverse it. 
		spell.effect.attackTimeMod = 1 / attackTimeSlider.value;
		spell.effect.knockbackMod = knockbackSlider.value;
		spell.effect.speedMod = speedSlider.value;
		spell.effect.jumpSpeedMod = jumpSpeedSlider.value;
		spell.effect.instantDamage = instantDamageSlider.value;
		spell.effect.instantKnockback = instantKnockbackSlider.value;
		spell.projectileSpeed = projectileSpeedSlider.value;
		spell.radius = radiusSlider.value;
		spell.effect.duration = durationSlider.value;

		spell.targetsEnemies = targetToggle.isOn;
		spell.isSelfSpell = self.isOn;
		spell.AoE = AoE.isOn;
		spell.affectedByGravity = affectedByGravity.isOn;

		radiusLabel.text = "AoE Radius: " + radiusSlider.value.ToString("F1");
		durationLabel.text = "Duration: " + durationSlider.value.ToString("F2") + "s";
	}
}