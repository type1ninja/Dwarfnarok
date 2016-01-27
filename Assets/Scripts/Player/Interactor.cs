using UnityEngine;
using System.Collections;

public class Interactor : MonoBehaviour {

	Transform charHead;
	//Various customizer panels
	GameObject wepCustomizerPanel;
	PlayerMove mover;
	SimpleSmoothMouseLook mouseLook;
	PlayerWepControl wepControl;

	float range = 1000.0f;

	void Start() {
		charHead = transform.Find ("CharacterHead");

		wepCustomizerPanel = GameObject.Find ("WeaponCustomizerPanel");
		wepCustomizerPanel.SetActive (false);

		mover = GetComponent<PlayerMove> ();
		mouseLook = GetComponentInChildren<SimpleSmoothMouseLook> ();
		wepControl = GetComponent<PlayerWepControl> ();
	}

	//TODO - MAKE THE INTERACT BUTTON CLOSE OPEN MENUS
	void Update() {
		if (Input.GetButton ("Interact")) {
			//TODO - MAKE RAYCAST NOT HIT PLAYER
			RaycastHit hit;
			if (Physics.Raycast(transform.position, charHead.forward, out hit, range)) {
				//Long list of possible tags for an "interactable" object
				string hitTag = hit.transform.tag;
				if (hitTag.Equals ("WeaponCustomizer")) {
					wepCustomizerPanel.SetActive (true);
					mover.canMove = false;
					mouseLook.shouldLook = false;
					wepControl.canSwing = false;
				} //else if (hitTag.Equals("SomeOtherTag"))...
			}
		}
	}
}