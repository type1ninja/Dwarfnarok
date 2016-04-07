using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WepCustomizer : MonoBehaviour {

	PlayerWepControl wepControl;
	PlayerSpellControl spellControl;
	PlayerMove mover;
	WeaponSize wepSize;
	SimpleSmoothMouseLook mouseLook;

	Slider headSlider;
	Slider handleSlider;
	Dropdown typeDrop;
	Text statText;

	void Start() {
		wepControl = GameObject.Find ("Player").GetComponent<PlayerWepControl> ();
		spellControl = GameObject.Find ("Player").GetComponent<PlayerSpellControl> ();
		wepSize = GameObject.Find ("Player").GetComponent<WeaponSize> ();

		mover = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		mouseLook = GameObject.Find ("Player").GetComponentInChildren<SimpleSmoothMouseLook> ();

		headSlider = transform.Find ("HeadSizeSlider").GetComponent<Slider> ();
		handleSlider = transform.Find ("HandleSizeSlider").GetComponent<Slider> ();
		typeDrop = transform.Find ("TypeDropdown").GetComponent<Dropdown> ();
		statText = transform.Find ("StatIndicator").GetComponent<Text> ();
	}

	public void Reset() {
		headSlider.value = 1;
		handleSlider.value = 1;
	}

	void Update () {
		//TODO - allow the interaction button to close this as well; 
		//just adding a check makes it so it reopens it pretty much instantly
		if (Input.GetButton ("Cancel")) {
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

		//Update display
		statText.text = "Damage: " + wepControl.GetDamage ().ToString ("F2") + "\nKnockback: " + wepControl.GetKnockback ().ToString ("F2") + "\nSwing Time: " + wepControl.GetMaxSwingTime().ToString ("F2");
	}
}