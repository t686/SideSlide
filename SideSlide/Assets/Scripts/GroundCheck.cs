using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private static string lastTag = "hh";

	private PlayerControl player;

	public static bool isOnEdge = false;

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
			isOnEdge = true;
			PlayerControl.IncrementAngle();
		}
	}

	void OnTriggerStay2D(Collider2D col){
		player.isGrounded = true;
	}


	void OnTriggerExit2D(Collider2D col){
		player.isGrounded = false;
		isOnEdge = false;
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
