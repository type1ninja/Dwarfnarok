using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageDealer : MonoBehaviour {

	CharacterWepControl charWepCtrl;

	List<Transform> hitTrans;

	void Start() {
		charWepCtrl = GetComponentInParent<CharacterWepControl> ();
		hitTrans = new List<Transform> ();
	}

	public void ResetHitList() {
		hitTrans = new List<Transform> ();
	}

	//Check if you're intersecting something
	void OnTriggerEnter(Collider other) {

		//Check if you're actually swinging - people just walking into weapons and dying would be bad
		if (charWepCtrl.GetIsSwinging()) {

			//Make sure it's not a child of yourself
			if (!other.transform.IsChildOf (transform)) {

				//Check if it's supposed to take damage
				if (other.tag.Equals ("AI") || other.tag.Equals ("Player")) {

					//Check if it's in the list of stuff you've hit during this swing
					//If it is, skip it
					if (!hitTrans.Contains (other.transform)) {

						//Actually deal the damage :P
						hitTrans.Add(other.transform);
						other.GetComponentInParent<CharacterHealthMana>().ModHealth (-1 * charWepCtrl.GetDamage ());
						//TODO - KNOCKBACK
					}
				}
			}
		}
	}
}