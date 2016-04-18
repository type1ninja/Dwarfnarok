using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageDealer : MonoBehaviour {

	CharacterWepControl charWepCtrl;

	List<Transform> hitTrans;

	static Vector3 KNOCKBACK_OFFSET = new Vector3(0, 2f, 0);

	void Start() {
		charWepCtrl = GetComponentInParent<CharacterWepControl> ();
		hitTrans = new List<Transform> ();
	}

	public void ResetHitList() {
		hitTrans = new List<Transform> ();
	}

	//Check if you're intersecting something
	void OnTriggerStay(Collider other) {

		//Check if you're actually swinging - people just walking into weapons and dying would be bad
		if (charWepCtrl.GetIsSwinging()) {

			//Make sure it's not a child of yourself
			if (!other.transform.IsChildOf (transform)) {

				//Check if it's supposed to take damage
				if (other.tag.Equals ("AI")) {

					//Check if it's in the list of stuff you've hit during this swing
					//If it is, skip it
					if (!hitTrans.Contains (other.transform)) {

						//Add it to the list of things hit during this swing
						hitTrans.Add(other.transform);
						//Deal the damage
						other.GetComponentInParent<CharacterHealthMana>().ModHealth (-1 * charWepCtrl.GetDamage ());
						//Do knockback
						Vector3 force = KNOCKBACK_OFFSET + other.transform.root.position - transform.root.position; 
						force.Normalize ();
						force *= charWepCtrl.GetKnockback ();
						other.GetComponentInParent<CharacterMove>().AddKnockback(force);
					}
				}
			}
		}
	}
}