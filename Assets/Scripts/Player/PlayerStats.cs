using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	//All of these are modifiers, which can be changed through various means

	public float currentHealth;
	public float healthRegen;
	public float maxHealth;
	public float damageReduction;

	public float currentMana;
	public float manaRegen;
	public float maxMana;

	public float damage;
	public float knockback;
	public float attackSpeed;

	public float speed;
	public float jumpSpeed;
}