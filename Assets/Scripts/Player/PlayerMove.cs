using UnityEngine;
using System.Collections;

public class PlayerMove : CharacterMove {

	public bool canMove = true;

	protected override Vector3 GetInput() {
		if (canMove) {
			return new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		} else {
			return Vector3.zero;
		}
	}

	protected override bool GetJump() {
		if (canMove) {
			return Input.GetButton ("Jump");
		} else {
			return false;
		}
	}
}