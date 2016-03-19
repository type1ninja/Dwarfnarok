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

	float range = 1000.0f;

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
	}

	void DisablePlayer() {
		mover.canMove = false;
		mouseLook.shouldLook = false;
		wepControl.canSwing = false;
		spellControl.canFire = false;
	}

	//TODO - MAKE THE INTERACT BUTTON CLOSE OPEN MENUS
	void Update() {
		if (Input.GetButton ("Interact")) {
			//TODO - MAKE RAYCAST NOT HIT PLAYER
			RaycastHit hit;
			if (Physics.Raycast(transform.position, charHead.forward, out hit, range)) {

				//Long list of possible tags for an "interactable" object
				string hitTag = hit.transform.tag;

				//Overall disabling
				if (hitTag.Equals ("WeaponCustomizer") || hitTag.Equals ("ArmorCustomizer") || hitTag.Equals ("SpellCustomizer")) {
					DisablePlayer ();

					if (hitTag.Equals ("WeaponCustomizer")) {
						wepCustomizerPanel.SetActive (true);
					} else if (hitTag.Equals ("ArmorCustomizer")) {
						armorCustomizerPanel.SetActive (true);
					} else if (hitTag.Equals ("SpellCustomizer")) {
						spellCustomizerPanel.SetActive (true);
					}
				} 
			}
		}
	}
}