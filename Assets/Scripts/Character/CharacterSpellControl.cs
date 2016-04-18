using UnityEngine;
using System.Collections;

public abstract class CharacterSpellControl : MonoBehaviour {

	public GameObject projectilePrefab;

	Transform headTransform;
	Transform handTransform;
	Collider col;
	ParticleSystem handParticles;
	CharacterHealthMana healthmana;
	CharacterStats stats;
	CharacterEffects charEffects;
	CharacterMove move;

	//TODO - do dual wield + multiple weapons. For now, though, single-weapon single-wield is fine.
	public Spell spell = new Spell();

	float maxAttackTime;
	//Decremented by the current fixedDeltaTime each FixedUpdate while the player is swinging. Reset once it reaches 0
	float currentAttackTime;
	bool isFiring = false;

	void Start() {
		healthmana = GetComponent<CharacterHealthMana> ();
		stats = GetComponent<CharacterStats> ();
		charEffects = GetComponent<CharacterEffects> ();
		move = GetComponent<CharacterMove> ();
		headTransform = transform.Find ("CharacterHead");
		handTransform = headTransform.Find ("LeftSpell");
		handParticles = handTransform.GetComponent<ParticleSystem> ();
	}

	//TODO - make firing speed dependent on player attack speed
	void FixedUpdate() {
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

		handParticles.startColor = spell.col;
	}

	//TODO - SPELL TYPES
	void Fire() {
		//Only allow swinging if the current swing is done
		if (!isFiring && healthmana.GetMana () > spell.manaCost) {
			isFiring = true;

			healthmana.ModMana (-1 * spell.manaCost);

			//If it's a projectile, targeting friendlies OR enemies
			if (!spell.isSelfSpell) {
				GameObject activeProjectile = (GameObject)Instantiate (projectilePrefab, handTransform.position, Quaternion.identity);
				activeProjectile.GetComponent<ProjectileSpell> ().SetSpellEffect (spell);
				activeProjectile.GetComponent<Rigidbody> ().AddForce (headTransform.forward * spell.projectileSpeed);

				Physics.IgnoreCollision (activeProjectile.GetComponent<Collider> (), GetComponent<Collider>());
				Physics.IgnoreCollision (activeProjectile.GetComponent<Collider> (), transform.Find ("CharacterHead").Find ("RightWep").Find ("RightWepHandle").GetComponent<Collider>());
				Physics.IgnoreCollision (activeProjectile.GetComponent<Collider> (), transform.Find ("CharacterHead").Find ("RightWep").Find ("RightWepBlade").GetComponent<Collider>());
			} //If it's a self spell that targets you (not an area around you)
			else if (spell.isSelfSpell && !spell.AoE) {
				charEffects.AddEffect (new SpellEffect (spell.effect));
				//Aesthetic spell spawn
				GameObject activeProjectile = (GameObject)Instantiate (projectilePrefab, handTransform.position, Quaternion.identity);
				//Set the spell to a blank one

				activeProjectile.GetComponent<ProjectileSpell> ().DestroySelf ();
				activeProjectile.GetComponent<ProjectileSpell> ().SetSpellEffect (new Spell());
				//Apply knockback only if there's actually knockback to apply
				if (spell.effect.instantKnockback != 0) {
					Vector3 force = headTransform.forward;
					force.y += .5f;
					force.Normalize ();
					force *= spell.effect.instantKnockback;
					//Stop all motion, then apply knockback--maybe change?
					move.StopMotion ();
					move.AddKnockback (force);
				}
			} //If it's a self spell that is AoE
			else if (spell.isSelfSpell && spell.AoE) {
				//Just spawn a projectile without any velocity
				GameObject activeProjectile = (GameObject)Instantiate (projectilePrefab, transform.position, Quaternion.identity);
				activeProjectile.GetComponent<ProjectileSpell> ().SetSpellEffect (spell);
				activeProjectile.GetComponent<ProjectileSpell> ().Explode ();
			}
		}
	}

	protected abstract bool CheckForFire();
}