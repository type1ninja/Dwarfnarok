using UnityEngine;
using System.Collections;

//Keep track of and switch between build and weapon mode for the player
public class PlayerMode : MonoBehaviour {
	GameObject rightWep;
	GameObject leftSpell;
	PlayerWepControl wepControl;
	PlayerSpellControl spellControl;
	PlayerBuild playerBuild;

	GameObject blockText;

	//Keeps track of which mode you're in. true = weapon mode, false = build mode
	bool isWeaponMode = true;

	void Start() {
		rightWep = transform.Find ("CharacterHead").Find ("RightWep").gameObject;
		leftSpell = transform.Find ("CharacterHead").Find ("LeftSpell").gameObject;
		wepControl = GetComponent<PlayerWepControl> ();
		spellControl = GetComponent<PlayerSpellControl> ();
		playerBuild = GetComponentInChildren<PlayerBuild> ();

		blockText = GameObject.Find ("BlockText");

		WeaponMode ();
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
		//Keep track of the mode
		isWeaponMode = true;

		//Enable weapon things
		rightWep.SetActive (true);
		leftSpell.SetActive(true);
		wepControl.enabled = true;
		spellControl.enabled = true;

		//Disable build things
		playerBuild.enabled = false;
		blockText.SetActive (false);
	}

	void BuildMode() {
		//Keep track of the mode
		isWeaponMode = false;

		//Disable weapon things
		rightWep.SetActive (false);
		leftSpell.SetActive(false);
		wepControl.enabled = false;
		spellControl.enabled = false;

		//Enable build things
		playerBuild.enabled = true;
		blockText.SetActive (true);
	}
}