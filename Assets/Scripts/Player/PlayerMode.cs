using UnityEngine;
using System.Collections;

public class PlayerMode : MonoBehaviour {
	GameObject rightWep;
	GameObject leftSpell;
	PlayerWepControl wepControl;
	PlayerSpellControl spellControl;

	//Keeps track of which mode you're in. true = weapon mode, false = build mode
	bool isWeaponMode = true;

	void Start() {
		rightWep = transform.Find ("CharacterHead").Find ("RightWep").gameObject;
		leftSpell = transform.Find ("CharacterHead").Find ("LeftSpell").gameObject;
		wepControl = GetComponent<PlayerWepControl> ();
		spellControl = GetComponent<PlayerSpellControl> ();
	}

	void Update() {
		if (Input.GetButtonDown ("ToggleMode")) {
			Toggle ();
		}
	}

	//Toggles between build and weapon mode
	void Toggle() {
		if (isWeaponMode) {
			BuildMode ();
		} else {
			WeaponMode ();
		}
	}

	void WeaponMode() {
		isWeaponMode = true;

		rightWep.SetActive (true);
		leftSpell.SetActive(true);
		wepControl.enabled = true;
		spellControl.enabled = true;
	}

	void BuildMode() {
		isWeaponMode = false;

		rightWep.SetActive (false);
		leftSpell.SetActive(false);
		wepControl.enabled = false;
		spellControl.enabled = false;
	}
}