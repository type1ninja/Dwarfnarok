using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpellCustomizer : MonoBehaviour {

	Spell spell;

	PlayerWepControl wepControl;
	PlayerSpellControl spellControl;
	PlayerMove mover;
	SimpleSmoothMouseLook mouseLook;


	//Parent transforms for elements that need to be enabled/disabled
	Transform effectSliders;
	Transform effectLabels;
	Transform projectileSliders;
	Transform projectileCheckboxes;
	Transform projectileLabels;

	//All the GUI elements that need to be dynamic
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
	Slider durationSlider;

	Slider projectileSpeedSlider;
	Slider radiusSlider;
	Slider lifetimeSlider;
	Slider sizeSlider;
	Slider redSlider;
	Slider greenSlider;
	Slider blueSlider;

	Toggle targetToggle;
	Toggle self;
	Toggle AoE;
	Toggle affectedByGravity;

	Text durationLabel;

	Text lifetimeLabel;
	Image colorImage;
	
	Text costLabel;

	void Start () {
		spell = GameObject.Find ("Player").GetComponent<CharacterSpellControl> ().spell;

		wepControl = GameObject.Find ("Player").GetComponent<PlayerWepControl> ();
		spellControl = GameObject.Find ("Player").GetComponent<PlayerSpellControl> ();
		mover = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		mouseLook = GameObject.Find ("Player").GetComponentInChildren<SimpleSmoothMouseLook> ();

		//Parent elements for easy enabling/disabling
		effectSliders = transform.Find("EffectSliders");
		effectLabels = transform.Find ("EffectLabels");
		projectileSliders = transform.Find ("ProjectileSliders");
		projectileLabels = transform.Find ("ProjectileLabels");
		projectileCheckboxes = transform.Find ("ProjectileCheckboxes");

		//Effect Sliders
		maxHealthSlider = effectSliders.Find ("MaxHealthSlider").GetComponent<Slider> ();
		healthRegenSlider = effectSliders.Find ("HealthRegenSlider").GetComponent<Slider> ();
		damageReductionSlider = effectSliders.Find ("DamageReductionSlider").GetComponent<Slider> ();
		maxManaSlider = effectSliders.Find ("MaxManaSlider").GetComponent<Slider> ();
		manaRegenSlider = effectSliders.Find ("ManaRegenSlider").GetComponent<Slider> ();
		damageSlider = effectSliders.Find ("DamageSlider").GetComponent<Slider> ();
		attackTimeSlider = effectSliders.Find ("AttackTimeSlider").GetComponent<Slider> ();
		knockbackSlider = effectSliders.Find ("KnockbackSlider").GetComponent<Slider> ();
		speedSlider = effectSliders.Find ("SpeedSlider").GetComponent<Slider> ();
		jumpSpeedSlider = effectSliders.Find ("JumpSpeedSlider").GetComponent<Slider> ();
		instantDamageSlider = effectSliders.Find ("InstantDamageSlider").GetComponent<Slider> ();
		instantKnockbackSlider = effectSliders.Find ("InstantKnockbackSlider").GetComponent<Slider> ();
		durationSlider = effectSliders.Find ("DurationSlider").GetComponent<Slider> ();

		//Effect Labels
		durationLabel = effectLabels.Find ("DurationLabel").GetComponent<Text> ();

		//Projectile Sliders
		projectileSpeedSlider = projectileSliders.Find ("ProjectileSpeedSlider").GetComponent<Slider>();
		radiusSlider = projectileSliders.Find ("RadiusSlider").GetComponent<Slider> ();
		lifetimeSlider = projectileSliders.Find ("LifetimeSlider").GetComponent<Slider> ();
		sizeSlider = projectileSliders.Find ("SizeSlider").GetComponent<Slider> ();
		redSlider = projectileSliders.Find ("RedSlider").GetComponent<Slider> ();
		greenSlider = projectileSliders.Find ("GreenSlider").GetComponent<Slider> ();
		blueSlider = projectileSliders.Find ("BlueSlider").GetComponent<Slider> ();

		//Projectile Checkboxes
		targetToggle = projectileCheckboxes.Find ("TargetsEnemies").GetComponent<Toggle> ();
		self = projectileCheckboxes.Find ("Self").GetComponent<Toggle> ();
		affectedByGravity = projectileCheckboxes.Find ("Gravity").GetComponent<Toggle> ();
		AoE = projectileCheckboxes.Find ("AoE").GetComponent<Toggle> ();

		//Projectile Labels (and an image)
		lifetimeLabel = projectileLabels.Find("LifetimeLabel").GetComponent<Text>();
		colorImage = projectileLabels.Find ("ColorImage").GetComponent<Image> ();

		//Cost is its own thing, not parented to anything. It always shows up
		costLabel = transform.Find ("CostLabel").GetComponent<Text> ();

		//Activate one of the menus so we don't get overlap
		ActivateEffectsMenu ();
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
		durationSlider.value = 3;

		projectileSpeedSlider.value = 2500;
		radiusSlider.value = 1;
		lifetimeSlider.value = 1;
		sizeSlider.value = 1;
		redSlider.value = 1;
		greenSlider.value = 1;
		blueSlider.value = 1;

		targetToggle.isOn = true;
		self.isOn = false;
		AoE.isOn = false;
		affectedByGravity.isOn = true;
	}
	
	//TODO - ALLOW CUSTOMIZATION OF INSTANT EFFECTS, AOE, FRIENDLY/ENEMY TARGETING, SHOW MANA COST
	void Update () {

		//TODO - allow the interaction button to close this as well
		if (Input.GetButtonDown ("Cancel") || Input.GetButtonDown ("Interact")) {
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
		spell.effect.duration = durationSlider.value;

		spell.projectileSpeed = projectileSpeedSlider.value;
		spell.radius = radiusSlider.value;
		spell.lifetime = lifetimeSlider.value;
		spell.size = sizeSlider.value;
		spell.col.r = redSlider.value;
		spell.col.g = greenSlider.value;
		spell.col.b = blueSlider.value;

		spell.targetsEnemies = targetToggle.isOn;
		spell.isSelfSpell = self.isOn;
		spell.AoE = AoE.isOn;
		spell.affectedByGravity = affectedByGravity.isOn;

		durationLabel.text = "Duration: " + durationSlider.value.ToString("F0") + "s";

		lifetimeLabel.text = "Lifetime: " + lifetimeSlider.value.ToString ("F0") + "s";
		colorImage.color = new Color (redSlider.value, greenSlider.value, blueSlider.value);

		costLabel.text = "Cost: " + spell.manaCost.ToString ("F0");

		spell.CalculateCost ();
	}

	//One of two methods for toggling between customizing effects and customizing the projectile
	public void ActivateEffectsMenu () {
		//Hack-y scaling workaround to make menu items invisible without disabling them
		//We "enable" effect menu stuff and "disable" projectile menu stuff
		effectSliders.localScale = new Vector3 (1, 1, 1);
		effectLabels.localScale = new Vector3 (1, 1, 1);

		projectileSliders.localScale = new Vector3 (0, 0, 0);
		projectileCheckboxes.localScale = new Vector3 (0, 0, 0);
		projectileLabels.localScale = new Vector3 (0, 0, 0);
	}

	//The same as the above, but instead we "enable" the projectile stuff and "disable" the effect stuff
	public void ActivateProjectileMenu () {
		effectSliders.localScale = new Vector3 (0, 0, 0);
		effectLabels.localScale = new Vector3 (0, 0, 0);

		projectileSliders.localScale = new Vector3 (1, 1, 1);
		projectileCheckboxes.localScale = new Vector3 (1, 1, 1);
		projectileLabels.localScale = new Vector3 (1, 1, 1);
	}
}