using UnityEngine;
using System.Collections;

public class AIMove : CharacterMove {

	protected override Vector3 GetInput() {
		//TODO - Stuff
		return new Vector3 (0, 0, 0);
	}
	
	protected override bool GetJump() {
		//TODO - Stuff
		return false;
	}
}