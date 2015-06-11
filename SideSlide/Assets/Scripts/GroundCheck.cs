using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private PlayerControl player;

	// Bounce check
	private bool wasYellow = false;
	private bool wasGreen = false;
	private bool wasBlue = false;
	private bool wasRed = false;
	//

	void Start(){
		player = gameObject.GetComponentInParent<PlayerControl>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == this.tag){
			//Do something

			if(!wasYellow) {       // if there was no bounce, than do something
				Debug.Log(1);
			}

			CheckBounce(col.tag);  // Detecting bounces

		}
		player.isGrounded = true;

		if(col.tag == "Edge") {
			PlayerControl.IncrementAngle();
		}
	}

	void OnTriggerStay2D(Collider2D col){
		player.isGrounded = true;
	}


	void OnTriggerExit2D(Collider2D col){
		player.isGrounded = false;
	}

	void CheckBounce(string tag) {

		switch(tag) {

		case "red":
			wasYellow = false;
			wasGreen = false;
			wasBlue = false;
			wasRed = true;
			break;
		
		case "yellow":
			wasYellow = true;
			wasGreen = false;
			wasBlue = false;
			wasRed = false;
			break;

		case "green":
			wasYellow = false;
			wasGreen = true;
			wasBlue = false;
			wasRed = false;
			break;

		case "blue":
			wasYellow = false;
			wasGreen = false;
			wasBlue = true;
			wasRed = false;
			break;
		}
	}
}
