using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private string lastTag = "";

	private PlayerControl player;

	void Start(){
		player = gameObject.GetComponentInParent<PlayerControl>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == this.tag && !isBounce(this.tag)){
			Debug.Log("Match");
			PlayerControl.PLAYER_COMBO++;
		}else{
			player.spawnPlayer();
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

	public bool isBounce(string tag) {
		if(lastTag == tag){
			return true;
		}
		else {
			lastTag = tag;
			return false;
		}
	}
}
