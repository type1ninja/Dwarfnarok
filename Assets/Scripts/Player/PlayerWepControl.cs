using UnityEngine;
using System.Collections;

public class PlayerWepControl : CharacterWepControl {

	protected override bool CheckForSwing() {
		if (Input.GetButton ("PrimaryFire")) {
			return true;
		} else {
			return false;
		}
	}
}