using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WepCustomizer : MonoBehaviour {

	PlayerWepControl wepControl;
	PlayerSpellControl spellControl;
	PlayerMove mover;
	WeaponSize wepSize;
	SimpleSmoothMouseLook mouseLook;

	Renderer bladeRenderer;
	Renderer handleRenderer;

	Slider headSlider;
	Slider handleSlider;
	Dropdown typeDrop;
	Text statText;

	Slider bladeRedSlider;
	Slider bladeGreenSlider;
	Slider bladeBlueSlider;
	Image bladeColorImage;

	Slider handleRedSlider;
	Slider handleGreenSlider;
	Slider handleBlueSlider;
	Image handleColorImage;

	void Start() {
		wepControl = GameObject.Find ("Player").GetComponent<PlayerWepControl> ();
		spellControl = GameObject.Find ("Player").GetComponent<PlayerSpellControl> ();
		mover = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		wepSize = GameObject.Find ("Player").GetComponent<WeaponSize> ();
		mouseLook = GameObject.Find ("Player").GetComponentInChildren<SimpleSmoothMouseLook> ();

		bladeRenderer = GameObject.Find ("Player").transform.Find ("CharacterHead").Find ("RightWep").Find ("RightWepBlade").GetComponent<Renderer>();
		handleRenderer = GameObject.Find ("Player").transform.Find ("CharacterHead").Find ("RightWep").Find ("RightWepHandle").GetComponent<Renderer>();

		headSlider = transform.Find ("HeadSizeSlider").GetComponent<Slider> ();
		handleSlider = transform.Find ("HandleSizeSlider").GetComponent<Slider> ();
		typeDrop = transform.Find ("TypeDropdown").GetComponent<Dropdown> ();
		statText = transform.Find ("StatIndicator").GetComponent<Text> ();

		Transform colorStuff = transform.Find ("ColorCustomizers");

		bladeRedSlider = colorStuff.Find ("BladeRedSlider").GetComponent<Slider>();
		bladeGreenSlider = colorStuff.Find ("BladeGreenSlider").GetComponent<Slider>();
		bladeBlueSlider = colorStuff.Find ("BladeBlueSlider").GetComponent<Slider>();
		bladeColorImage = colorStuff.Find ("BladeColorImage").GetComponent<Image>();

		handleRedSlider = colorStuff.Find ("HandleRedSlider").GetComponent<Slider>();
		handleGreenSlider = colorStuff.Find ("HandleGreenSlider").GetComponent<Slider>();
		handleBlueSlider = colorStuff.Find ("HandleBlueSlider").GetComponent<Slider>();
		handleColorImage = colorStuff.Find ("HandleColorImage").GetComponent<Image>();
	}

	public void Reset() {
		headSlider.value = 1;
		handleSlider.value = 1;

		bladeRedSlider.value = .5f;
		bladeGreenSlider.value = .5f;
		bladeBlueSlider.value = .5f;

		handleRedSlider.value = .5f;
		handleGreenSlider.value = .5f;
		handleBlueSlider.value = .5f;
	}

	void Update () {
		//TODO - allow the interaction button to close this as well; 
		//right now allowing the button to close it ALSO raycasts at the box, re-opening the menu
		if (Input.GetButtonDown ("Cancel") || Input.GetButtonDown ("Interact")) {
			mover.canMove = true;
			mouseLook.shouldLook = true;
			wepControl.canSwing = true;
			spellControl.canFire = true;
			gameObject.SetActive (false);
		}

		switch (typeDrop.value) {
		case 0: 
			wepControl.wep.UpdateStats(WeaponType.SWORD, handleSlider.value, headSlider.value);
			wepSize.UpdateSize (WeaponType.SWORD, headSlider.value, handleSlider.value);
			break;
		case 1: 
			wepControl.wep.UpdateStats(WeaponType.AXE, handleSlider.value, headSlider.value);
			wepSize.UpdateSize (WeaponType.AXE, headSlider.value, handleSlider.value);
			break; 
		case 2: 
			wepControl.wep.UpdateStats(WeaponType.HAMMER, handleSlider.value, headSlider.value);
			wepSize.UpdateSize (WeaponType.HAMMER, headSlider.value, handleSlider.value);
			break;
		} //TODO - torch + shield

		bladeRenderer.material.color = new Color (bladeRedSlider.value, bladeGreenSlider.value, bladeBlueSlider.value);
		handleRenderer.material.color = new Color (handleRedSlider.value, handleGreenSlider.value, handleBlueSlider.value);

		//Update display
		statText.text = "Damage: " + wepControl.GetDamage ().ToString ("F2") + "\nKnockback: " + wepControl.GetKnockback ().ToString ("F2") + "\nSwing Time: " + wepControl.GetMaxSwingTime().ToString ("F2");
		bladeColorImage.color = new Color (bladeRedSlider.value, bladeGreenSlider.value, bladeBlueSlider.value);
		handleColorImage.color = new Color (handleRedSlider.value, handleGreenSlider.value, handleBlueSlider.value);
	}
}