using UnityEngine;
using System.Collections;

public class PlayerSpellControl : CharacterSpellControl {
	public bool canFire = true;
	
	protected override bool CheckForFire() {
		if (Input.GetButton ("SecondaryFire") && canFire) {
			return true;
		} else {
			return false;
		}
	}
}