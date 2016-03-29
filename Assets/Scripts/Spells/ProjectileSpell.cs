using UnityEngine;
using System.Collections;

//Goes on the projectile prefab
public class ProjectileSpell : MonoBehaviour {

	SpellEffect effect;

	static Vector3 KNOCKBACK_OFFSET = new Vector3(0, .5f, 0);

	public Rigidbody rb;
	//The current velocity--needed for lastVelocity
	Vector3 velocity = Vector3.zero;
	//The velocity of the spell last tick
	Vector3 lastVelocity;

	float deathTimer = 8f;

	bool targetsEnemies = true;
	bool AoE = false;

	//To keep track of whether an AoE spell has exploded
	bool hasExploded = false;
	float radius = 1;

	void FixedUpdate() {
		deathTimer -= Time.fixedDeltaTime;
		if (deathTimer <= 0) {
			Destroy (gameObject);
		}
		//Record the velocity
		lastVelocity = velocity;
		velocity = rb.velocity;
	}

	public void SetSpellEffect(Spell newSpell) {
		effect = new SpellEffect (newSpell.effect);
		targetsEnemies = newSpell.targetsEnemies;
		AoE = newSpell.AoE;
		rb.useGravity = newSpell.affectedByGravity;
		radius = newSpell.radius;
	}

	void OnTriggerEnter(Collider other) {
		//If a spell targets enemies and is hitting an enemy,
		if ((targetsEnemies && other.gameObject.tag.Equals ("AI")) 
			//or targets friendlies and is hitting a friendly--TODO replace "false" with friendly AI tag
			|| (!targetsEnemies && (other.gameObject.tag.Equals("Player") || false))) {

			other.gameObject.GetComponent<CharacterEffects> ().AddEffect (effect);

			Vector3 force;
			if (!AoE) {
				//Use the lastVelocity, the one before you hit the target
				force = lastVelocity.normalized;
			} else {
				force = other.transform.position - transform.position; 
			}
			force.Normalize ();
			force += KNOCKBACK_OFFSET;
			force *= effect.instantKnockback;
			other.gameObject.GetComponentInParent<CharacterMove> ().AddKnockback (force);
			//TODO - If you hit a rigid body, apply knockback to those?
		} 

		//If you are AoE and haven't exploded, set yourself to explode next tick as well as increasing the radius.
		if (AoE && !hasExploded) {
			Explode ();
		} else {
			if (GetComponentInChildren<ParticleSystem> ()) {
				GetComponentInChildren<ParticleSystem> ().Stop ();
				transform.DetachChildren ();
			}
			Destroy (gameObject);
		}
	}

	public void Explode() {
		hasExploded = true;
		GetComponent<SphereCollider> ().radius = radius;
	}
}