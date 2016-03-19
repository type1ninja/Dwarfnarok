using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WepCustomizer : MonoBehaviour {

	PlayerWepControl wepControl;
	PlayerSpellControl spellControl;
	PlayerMove mover;
	SimpleSmoothMouseLook mouseLook;

	Slider headSlider;
	Slider handleSlider;
	Text statText;

	void Start() {
		wepControl = GameObject.Find ("Player").GetComponent<PlayerWepControl> ();
		spellControl = GameObject.Find ("Player").GetComponent<PlayerSpellControl> ();

		mover = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		mouseLook = GameObject.Find ("Player").GetComponentInChildren<SimpleSmoothMouseLook> ();

		headSlider = transform.Find ("Sliders").Find ("HeadSizeSlider").GetComponent<Slider> ();
		handleSlider = transform.Find ("Sliders").Find ("HandleSizeSlider").GetComponent<Slider> ();
		statText = transform.Find ("Sliders").Find ("StatIndicator").GetComponent<Text> ();
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

		//TODO - Also update weapontype
		wepControl.wep.UpdateStats(wepControl.wep.type, handleSlider.value, headSlider.value);
		//Update display
		statText.text = "Damage: " + wepControl.GetDamage ().ToString ("F2") + "\nKnockback: " + wepControl.GetKnockback ().ToString ("F2") + "\nSwing Time: " + wepControl.GetMaxSwingTime().ToString ("F2");
	}
}