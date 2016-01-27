using UnityEngine;
using System.Collections;

//Taken from the Unity3D documention
//http://docs.unity3d.com/ScriptReference/CharacterController.Move.html
//Some slight modifications were made for Dwarfnarok
public abstract class CharacterMove : MonoBehaviour {

	CharacterController controller;
	CharacterStats stats;

	float speed;
	float jumpSpeed;
	float gravity = Physics.gravity.y;

	Vector3 moveDirection = Vector3.zero;

	void Start() {
		controller = GetComponent<CharacterController>();
		stats = GetComponent<CharacterStats> ();
	}

	void FixedUpdate() {
		speed = stats.GetSpeed();
		jumpSpeed = stats.GetJumpSpeed();

		if (controller.isGrounded) {
			moveDirection = GetInput ();
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//If the character is moving diagonally, divide magnitude by 1.4 to prevent huge speed buffs from diagonal walking
			if (moveDirection.x != 0 && moveDirection.z != 0) {
				moveDirection /= 1.4f;
			}
			if (GetJump()) {
				moveDirection.y = jumpSpeed;
			}
		}
		//ADD gravity because it's negative
		moveDirection.y += gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	
	//For the player, this is WASD
	//For AIs, this is pathfinding
	protected abstract Vector3 GetInput();
	//Similar to GetInput()
	protected abstract bool GetJump();
}