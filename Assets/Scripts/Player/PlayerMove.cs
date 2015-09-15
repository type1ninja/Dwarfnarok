using UnityEngine;
using System.Collections;

//Taken from the Unity3D documention
//http://docs.unity3d.com/ScriptReference/CharacterController.Move.html
//Some slight modifications were made for Dwarfnarok
public class PlayerMove : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;
	CharacterController controller;

	void Start() {
		controller = GetComponent<CharacterController>();
	}

	void Update() {
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//If the player is moving diagonally, divide magnitude by 1.4 to prevent huge speed buffs
			if (Input.GetAxis ("Horizontal") != 0 && Input.GetAxis ("Vertical") != 0) {
				moveDirection /= 1.4f;
			}
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}