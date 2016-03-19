using UnityEngine;
using System.Collections;

//Goes on the projectile prefab
public class ProjectileSpell : MonoBehaviour {

	SpellEffect effect;

	float deathTimer = 8f;

	void FixedUpdate() {
		deathTimer -= Time.fixedDeltaTime;
		if (deathTimer <= 0) {
			Destroy (gameObject);
		}
	}

	public void SetSpellEffect(SpellEffect newEffect) {
		effect = new SpellEffect (newEffect);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag.Equals ("AI") || collision.gameObject.tag.Equals("Player")) {
			collision.gameObject.GetComponent<CharacterEffects>().AddEffect (effect);
		}
		
		Destroy (gameObject);
	}
}