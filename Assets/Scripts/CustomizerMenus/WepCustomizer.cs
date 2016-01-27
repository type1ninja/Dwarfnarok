using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WepCustomizer : MonoBehaviour {

	PlayerWepControl wepControl;
	PlayerMove mover;
	SimpleSmoothMouseLook mouseLook;

	Slider headSlider;
	Slider handleSlider;
	Text statText;

	void Start() {
		wepControl = GameObject.Find ("Player").GetComponent<PlayerWepControl> ();
		mover = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		mouseLook = GameObject.Find ("Player").GetComponentInChildren<SimpleSmoothMouseLook> ();

		headSlider = transform.Find ("Sliders").Find ("HeadSizeSlider").GetComponent<Slider> ();
		handleSlider = transform.Find ("Sliders").Find ("HandleSizeSlider").GetComponent<Slider> ();
		statText = transform.Find ("Sliders").Find ("StatIndicator").GetComponent<Text> ();
	}

	void Update () {
		//TODO - allow the interaction button to close this as well
		if (Input.GetButton ("Cancel")) {
			mover.canMove = true;
			mouseLook.shouldLook = true;
			wepControl.canSwing = true;
			gameObject.SetActive (false);
		}

		//TODO - Also update weapontype
		wepControl.wep.UpdateStats(wepControl.wep.type, handleSlider.value, headSlider.value);
		//Update display
		statText.text = "Damage: " + wepControl.GetDamage () + "\nKnockback: " + wepControl.GetKnockback () + "\nSwing Time: " + wepControl.GetMaxSwingTime();
	}
}