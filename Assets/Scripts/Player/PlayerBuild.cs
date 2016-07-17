using UnityEngine;
using System.Collections;

//Place and destroy blocks
public class PlayerBuild : MonoBehaviour {

	string blockToPlace = "stone";

	void FixedUpdate() {

		if (Input.GetButtonDown ("PrimaryFire")) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, 100)) {
				Voxelmetric.SetBlock (hit, "air", false);
			}
		}
	
		if (Input.GetButtonDown ("SecondaryFire")) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, 100)) {
				Voxelmetric.SetBlock (hit, blockToPlace, true);
			}
		}
	}
}