using UnityEngine;
using System.Collections;

public class Torch : Weapon {

	public static float TORCH_HANDLE_LENGTH = 1.0f;
	public static float TORCH_HEAD_SIZE = .25f;

	public Torch() : base(WeaponType.SWORD, TORCH_HANDLE_LENGTH, TORCH_HEAD_SIZE) {
		//Stats for torches above
	}
}