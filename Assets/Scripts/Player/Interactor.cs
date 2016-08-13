using UnityEngine;
using System.Collections;

public class Interactor : MonoBehaviour {

	Transform charHead;
	//Various customizer panels
	GameObject wepCustomizerPanel;
	GameObject armorCustomizerPanel;
	GameObject spellCustomizerPanel;
	PlayerMove mover;
	SimpleSmoothMouseLook mouseLook;
	PlayerWepControl wepControl;
	PlayerSpellControl spellControl;
	GameState state;

	float range = 10.0f;

	void Start() {
		charHead = transform.Find ("CharacterHead");

		wepCustomizerPanel = GameObject.Find ("WeaponCustomizerPanel");
		wepCustomizerPanel.SetActive (false);

		armorCustomizerPanel = GameObject.Find ("ArmorCustomizerPanel");
		armorCustomizerPanel.SetActive (false);

		spellCustomizerPanel = GameObject.Find ("SpellCustomizerPanel");
		spellCustomizerPanel.SetActive (false);

		mover = GetComponent<PlayerMove> ();
		mouseLook = GetComponentInChildren<SimpleSmoothMouseLook> ();
		wepControl = GetComponent<PlayerWepControl> ();
		spellControl = GetComponent<PlayerSpellControl> ();

		state = GameObject.Find ("GameLogicScripts").GetComponent<GameState> ();
	}

	void DisablePlayer() {
		mover.canMove = false;
		mouseLook.shouldLook = false;
		wepControl.canSwing = false;
		spellControl.canFire = false;
	}
		
	void Update() {
		if (Input.GetButtonDown ("Interact") && !wepCustomizerPanel.activeInHierarchy && !armorCustomizerPanel.activeInHierarchy && !spellCustomizerPanel.activeInHierarchy) {
		
			RaycastHit hit;
			if (Physics.Raycast(charHead.position, charHead.forward, out hit, range)) {


				string hitTag = hit.transform.tag;

				//Long list of possible tags for an "interactable" object that opens a menu
				if (hitTag.Equals ("WeaponCustomizer") || hitTag.Equals ("ArmorCustomizer") || hitTag.Equals ("SpellCustomizer")) {
					//Overall disabling

					DisablePlayer ();

					if (hitTag.Equals ("WeaponCustomizer")) {
						wepCustomizerPanel.SetActive (true);
					} else if (hitTag.Equals ("ArmorCustomizer")) {
						armorCustomizerPanel.SetActive (true);
					} else if (hitTag.Equals ("SpellCustomizer")) {
						spellCustomizerPanel.SetActive (true);
					}
				} 

				//Long list of possible tracks for an "interactable" object that 
				if (hitTag.Equals ("StartAttacking")) {
					state.SetEnemiesAttacking (true);
				}
			}
		}
	}
}