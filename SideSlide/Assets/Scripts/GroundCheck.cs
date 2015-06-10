using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private int success = 0;
	
	private PlayerControl player;

	void Start(){
		player = gameObject.GetComponentInParent<PlayerControl>();
	}

	
	void OnTriggerEnter2D(Collider2D col){
		player.isGrounded = true;

		if(col.tag == this.tag){
			//Do something
			success += 1;
			CheckIfCombo(success);
		}

		if(col.tag == "kill") {
			PlayerControl.LifeDecrenment(PlayerControl.PLAYER_COMBO);
		}
	}

	void OnTriggerStay2D(Collider2D col){
		player.isGrounded = true;
	}


	void OnTriggerExit2D(Collider2D col){
		player.isGrounded = false;
	}

	void CheckIfCombo(int success) {
		if(success >= 5) {
			PlayerControl.PLAYER_COMBO += 1;
			this.success = 0;
		}
	}
}
