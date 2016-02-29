using UnityEngine;
	
//Found here: http://answers.unity3d.com/questions/309633/need-help-with-knockback-in-c-please.html
//Slightly modified for my purposes. Basically used for knockback. 
public class ImpactReceiver: MonoBehaviour {
		
	public float mass = 3.0f; // define the character mass

	Vector3 impact = Vector3.zero; 
	CharacterController character;

	bool wasGroundedLastFrame = false;
		
	void Start() { 
		character = GetComponent< CharacterController>(); 
	}
		
	public void AddImpact(Vector3 force) { // CharacterController version of AddForce 
		//Move up a *tiny* bit so that you are no longer considered grounded
		character.Move (new Vector3(0, 0.05f, 0));
		//Update impact
		impact += force / mass; 
	}
			
	void FixedUpdate() { // apply the impact effect
		//Reset y value if you touch the ground two ticks in a row
		if (character.isGrounded) {
			if (wasGroundedLastFrame) {
				impact = new Vector3 (impact.x, 0, impact.z);
			}
			wasGroundedLastFrame = true;
		} else {
			wasGroundedLastFrame = false;
		}

		if (impact.magnitude > 0) {
			character.Move (impact * Time.deltaTime);
		} 

		//Reduce impact
		impact = Vector3.Lerp (impact, Vector3.zero, Time.deltaTime); 

		//TODO - stop the thing where you slide along the ground after they land
	}
}