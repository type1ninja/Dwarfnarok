using UnityEngine;
using System.Collections;

public class AISpellControl : CharacterSpellControl {
	protected override bool CheckForFire() {
		return false;
	}
}