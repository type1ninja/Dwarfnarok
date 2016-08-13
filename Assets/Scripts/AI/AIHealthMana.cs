using UnityEngine;
using System.Collections;

public class AIHealthMana : CharacterHealthMana {

	GameObject healthbar;

	//On death, destroy this object and the healthbar
	protected override void Die() {
		Destroy (healthbar);
		Destroy (gameObject);
	}

	public void SetHealthbar(GameObject newBar) {
		healthbar = newBar;
	}
}