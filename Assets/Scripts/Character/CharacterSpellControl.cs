using UnityEngine;
using System.Collections;

public class CharacterSpellControl : MonoBehaviour {

	public GameObject projectilePrefab;

	Transform headTransform;
	Collider col;
	CharacterHealthMana healthmana;
	CharacterStats stats;

	//TODO - do dual wield + multiple weapons. For now, though, single-weapon single-wield is fine.
	Spell spell;

	float maxAttackTime;
	//Decremented by the current fixedDeltaTime each FixedUpdate while the player is swinging. Reset once it reaches 0
	float currentAttackTime;
	bool isFiring = false;

	Vector3 handPos = new Vector3(0.038f, -.629f, .534f);

	void Start() {
		healthmana = GetComponent<CharacterHealthMana> ();
		stats = GetComponent<CharacterStats> ();
		headTransform = transform.Find ("CharacterHead");
		col = GetComponent<Collider> ();

		spell = new Spell();
	}

	void FixedUpdate() {
		//TODO - DIVIDE BETWEEN PLAYER AND AI
		if (Input.GetButton ("SecondaryFire")) {
			Fire();
		}
		
		maxAttackTime = stats.GetAttackTime() * spell.attackTime;
		if (!isFiring) {
			currentAttackTime = maxAttackTime;
		}
		
		if (isFiring) {
			currentAttackTime -= Time.fixedDeltaTime;
			
			if (currentAttackTime <= 0) {
				currentAttackTime = maxAttackTime;
				isFiring = false;
			}
		}
	}

	//TODO - SPELL TYPES
	protected void Fire() {
		//Only allow swinging if the current swing is done
		if (!isFiring && healthmana.GetMana () > spell.manaCost) {
			isFiring = true;

			healthmana.ModMana (-1 * spell.manaCost);

			GameObject activeProjectile = (GameObject) Instantiate(projectilePrefab, headTransform.position + handPos, Quaternion.identity);
			activeProjectile.GetComponent<ProjectileSpell>().SetSpellEffect (spell.effect);
			activeProjectile.GetComponent<Rigidbody>().AddForce (headTransform.forward * spell.projectileSpeed);

			Physics.IgnoreCollision (activeProjectile.GetComponent<Collider>(), col);
		}
	}
}