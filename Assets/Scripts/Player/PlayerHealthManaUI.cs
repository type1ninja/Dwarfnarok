using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//TODO - Mana.
public class PlayerHealthManaUI : MonoBehaviour {
	CharacterHealthMana healthScript;
	Slider healthSlider; 
	Slider manaSlider;

	void Start() {
		healthScript = GetComponent<CharacterHealthMana> ();
		healthSlider = GameObject.Find ("HUDCanvas").transform.Find("StatsPanel").Find("PlayerHealthBar").GetComponent<Slider> ();
		manaSlider = GameObject.Find ("HUDCanvas").transform.Find("StatsPanel").Find("PlayerManaBar").GetComponent<Slider> ();
	}

	void Update() {
		healthSlider.value = healthScript.GetHealth ();
		manaSlider.value = healthScript.GetMana ();

		healthSlider.maxValue = healthScript.GetMaxHealth ();
		manaSlider.maxValue = healthScript.GetMaxMana ();
	}
}