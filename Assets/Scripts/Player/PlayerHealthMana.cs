using UnityEngine;
using System.Collections;

public class PlayerHealthMana : CharacterHealthMana {
	protected override void Die() {
		transform.position = new Vector3 (9.5f, 35, 0);
		health = stats.GetMaxHealth();
		mana = stats.GetMaxMana ();
		move.StopMotion ();
	}
}