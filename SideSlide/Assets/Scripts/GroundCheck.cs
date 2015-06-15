using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private PlayerControl player;

	void Start(){
		player = gameObject.GetComponentInParent<PlayerControl>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == this.tag){
			//Stop addid if went to max
			Debug.Log("Match");
			PlayerControl.PLAYER_COMBO++;

		}else{
			player.spawnPlayer();
		}
		player.isGrounded = true;
	}

	void OnTriggerStay2D(Collider2D col){
		player.isGrounded = true;
	}


	void OnTriggerExit2D(Collider2D col){
		player.isGrounded = false;
	}
}
