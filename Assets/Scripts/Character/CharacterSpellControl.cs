using UnityEngine;
using System.Collections;

public abstract class CharacterSpellControl : MonoBehaviour {

	public GameObject projectilePrefab;

	Transform headTransform;
	Transform handTransform;
	Collider col;
	CharacterHealthMana healthmana;
	CharacterStats stats;

	//TODO - do dual wield + multiple weapons. For now, though, single-weapon single-wield is fine.
	public Spell spell = new Spell();

	float maxAttackTime;
	//Decremented by the current fixedDeltaTime each FixedUpdate while the player is swinging. Reset once it reaches 0
	float currentAttackTime;
	bool isFiring = false;

	void Start() {
		healthmana = GetComponent<CharacterHealthMana> ();
		stats = GetComponent<CharacterStats> ();
		headTransform = transform.Find ("CharacterHead");
		handTransform = headTransform.Find ("LeftSpell");
		col = GetComponent<Collider> ();
	}

	void FixedUpdate() {
		//TODO - DIVIDE BETWEEN PLAYER AND AI
		if (CheckForFire ()) {
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
	void Fire() {
		//Only allow swinging if the current swing is done
		if (!isFiring && healthmana.GetMana () > spell.manaCost) {
			isFiring = true;

			healthmana.ModMana (-1 * spell.manaCost);

			GameObject activeProjectile = (GameObject) Instantiate(projectilePrefab, handTransform.position, Quaternion.identity);
			activeProjectile.GetComponent<ProjectileSpell>().SetSpellEffect (spell.GetEffect());
			activeProjectile.GetComponent<Rigidbody>().AddForce (headTransform.forward * spell.projectileSpeed);

			Physics.IgnoreCollision (activeProjectile.GetComponent<Collider>(), col);
		}
	}

	protected abstract bool CheckForFire();
}