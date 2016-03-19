using UnityEngine;
using System.Collections;

public class PlayerWepControl : CharacterWepControl {

	public bool canSwing = true;

	protected override bool CheckForSwing() {
		if (Input.GetButton ("PrimaryFire") && canSwing) {
			return true;
		} else {
			return false;
		}
	}
}