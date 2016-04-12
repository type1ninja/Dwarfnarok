using UnityEngine;
using System.Collections;

public class WeaponSize : MonoBehaviour {

	//Sword scales
	static Vector3 DEFAULT_SWORD_BLADE_SCALE = new Vector3 (0.45f, 2f, 0.1f);
	static Vector3 DEFAULT_SWORD_HANDLE_SCALE = new Vector3 (0.15f, 0.4f, 0.1f);
	static Vector3 DEFAULT_SWORD_HANDLE_POS = new Vector3 (0, 0, 0.757f);
	static float DEFAULT_SWORD_BLADE_OFFSET = 0f;
	static float DEFAULT_SWORD_HANDLE_LENGTH_OFFSET = -1.25f;

	//Axe scales
	static Vector3 DEFAULT_AXE_BLADE_SCALE = new Vector3 (0.8f, 0.8f, 0.1f);
	static Vector3 DEFAULT_AXE_HANDLE_SCALE = new Vector3 (0.15f, 1.6f, 0.15f);
	static Vector3 DEFAULT_AXE_HANDLE_POS = new Vector3 (0, 1.024f, 0.757f);
	static float DEFAULT_AXE_BLADE_OFFSET = -0.1f;

	//Hammer scales
	static Vector3 DEFAULT_HAMMER_BLADE_SCALE = new Vector3 (0.6f, 0.5f, 0.5f);
	static Vector3 DEFAULT_HAMMER_HANDLE_SCALE = new Vector3 (0.15f, 1.6f, 0.15f);
	static Vector3 DEFAULT_HAMMER_HANDLE_POS = new Vector3 (0, 1.024f, 0.757f);
	static float DEFAULT_HAMMER_BLADE_OFFSET = -0.1f;

	public Transform bladeTrans;
	public Transform handleTrans;

	//Note that there ARE some differences between sword, axe, and hammer calculations
	public void UpdateSize(WeaponType newType, float bladeScale, float handleScale) {
		//TODO - make small blade + large handle not horribly broken
		if (newType == WeaponType.SWORD) {

			//The sword handle scale gets a special calculation applied to map the 1-2 scale to a 1-12 scale
			handleTrans.localScale = new Vector3 (DEFAULT_SWORD_HANDLE_SCALE.x, (DEFAULT_SWORD_HANDLE_SCALE.y * (((handleScale - 1.6f) * 6f) + 10f)) + DEFAULT_SWORD_HANDLE_LENGTH_OFFSET, DEFAULT_SWORD_HANDLE_SCALE.z);
			handleTrans.localPosition = DEFAULT_SWORD_HANDLE_POS;
			
			bladeTrans.localScale = new Vector3 (DEFAULT_SWORD_BLADE_SCALE.x * bladeScale, DEFAULT_SWORD_BLADE_SCALE.y * bladeScale, DEFAULT_SWORD_BLADE_SCALE.z);
			//Weird math to get the blade in the right spot
			bladeTrans.localPosition = new Vector3 (DEFAULT_SWORD_HANDLE_POS.x, handleTrans.localPosition.y + (handleTrans.localScale.y / 2) + (bladeTrans.localScale.y / 2) + DEFAULT_SWORD_BLADE_OFFSET, DEFAULT_SWORD_HANDLE_POS.z);
		
		} else if (newType == WeaponType.AXE) {

			handleTrans.localScale = new Vector3 (DEFAULT_AXE_HANDLE_SCALE.x, DEFAULT_AXE_HANDLE_SCALE.y * handleScale, DEFAULT_AXE_HANDLE_SCALE.z);
			handleTrans.localPosition = new Vector3 (DEFAULT_AXE_HANDLE_POS.x, DEFAULT_AXE_HANDLE_POS.y * handleScale * .75f, DEFAULT_AXE_HANDLE_POS.z);

			bladeTrans.localScale = new Vector3 (DEFAULT_AXE_BLADE_SCALE.x * bladeScale, DEFAULT_AXE_BLADE_SCALE.y * bladeScale, DEFAULT_AXE_BLADE_SCALE.z);
			//Weird math to get the blade in the right spot
			bladeTrans.localPosition = new Vector3 (DEFAULT_AXE_HANDLE_POS.x, handleTrans.localPosition.y + (handleTrans.localScale.y / 2) - (bladeTrans.localScale.y / 2) + DEFAULT_AXE_BLADE_OFFSET, DEFAULT_AXE_HANDLE_POS.z);

		} else if (newType == WeaponType.HAMMER) {

			handleTrans.localScale = new Vector3 (DEFAULT_HAMMER_HANDLE_SCALE.x, DEFAULT_HAMMER_HANDLE_SCALE.y * handleScale, DEFAULT_HAMMER_HANDLE_SCALE.z);
			handleTrans.localPosition = new Vector3 (DEFAULT_HAMMER_HANDLE_POS.x, DEFAULT_HAMMER_HANDLE_POS.y * handleScale * .75f, DEFAULT_HAMMER_HANDLE_POS.z);
			
			bladeTrans.localScale = new Vector3 (DEFAULT_HAMMER_BLADE_SCALE.x * bladeScale, DEFAULT_HAMMER_BLADE_SCALE.y * bladeScale, DEFAULT_HAMMER_BLADE_SCALE.z * bladeScale);
			//Weird math to get the blade in the right spot
			bladeTrans.localPosition = new Vector3 (DEFAULT_HAMMER_HANDLE_POS.x, handleTrans.localPosition.y + (handleTrans.localScale.y / 2) - (bladeTrans.localScale.y / 2) + DEFAULT_HAMMER_BLADE_OFFSET, DEFAULT_HAMMER_HANDLE_POS.z);
		}
	}
}