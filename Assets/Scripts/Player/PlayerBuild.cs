using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Place and destroy blocks
public class PlayerBuild : MonoBehaviour {

	Text blockText;

	//Array of different block names
	string[] blockToPlace = {"stone", "dirt", "grass", "leaves", "log"};
	//Current place in that array
	int blockToPlaceIndex = 0;
	//Max block placement range
	float range = 7;

	void Start() {
		blockText = GameObject.Find ("BlockText").GetComponent<Text> ();
	}

	void FixedUpdate() {

		//Scroll to change block
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			blockToPlaceIndex += 1;
		} 
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			blockToPlaceIndex -=1;
		}
		//Wrap around
		if (blockToPlaceIndex < 0) {
			blockToPlaceIndex = blockToPlace.Length - 1;
		}
		if (blockToPlaceIndex > blockToPlace.Length) {
			blockToPlaceIndex = 0;
		}

		//Keypress to change block
		if (Input.GetKey ("1")) {
			blockToPlaceIndex = 0;
		} else if (Input.GetKey ("2")) {
			blockToPlaceIndex = 1;
		} else if (Input.GetKey ("3")) {
			blockToPlaceIndex = 2;
		} else if (Input.GetKey ("4")) {
			blockToPlaceIndex = 3;
		} else if (Input.GetKey ("5")) {
			blockToPlaceIndex = 4;
		} 

		if (Input.GetButtonDown ("PrimaryFire")) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, range)) {
				Voxelmetric.SetBlock (hit, "air", false);
			}
		}
	
		if (Input.GetButtonDown ("SecondaryFire")) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, range)) {
				Voxelmetric.SetBlock (hit, blockToPlace[blockToPlaceIndex], true);
			}
		}
	}

	void Update() {
		blockText.text = blockToPlace [blockToPlaceIndex];
	}
}