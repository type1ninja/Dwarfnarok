using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//TODO - Mana.
public class PlayerHealthUI : MonoBehaviour {
	CharacterHealthMana healthScript;
	Slider slider; 

	void Start() {
		healthScript = GetComponent<CharacterHealthMana> ();
		slider = GameObject.Find ("HUDCanvas").transform.Find("StatsPanel").Find("PlayerHealthBar").GetComponent<Slider> ();
	}

	void Update() {
		slider.value = healthScript.GetHealth ();
	}
}