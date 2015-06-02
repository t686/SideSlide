using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float maxSpeed = 10f;		// The fastest the player can travel in the x axis.
	public float moveForce = 50f;		// Amount of force added to move the player left and right.
	public float jumpForce = 150f;		// Amount of force added when the player jumps.

	public bool isGrounded = false;		// Whether or not the player is grounded.

	//References
	private Animator anim;
	private Rigidbody2D rb2d;

	void Start(){
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		//anim = gameObject.GetComponent<Animator>():
	}
	
	void Update(){
		if(Input.GetButtonDown("Jump") && isGrounded){ 
			rb2d.AddForce(new Vector2(0, jumpForce));
		}
	}
	
	
	void FixedUpdate (){

		float h = Input.GetAxis("Horizontal");


		rb2d.AddForce(Vector2.right * h * moveForce);
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rb2d.velocity.x) > maxSpeed){
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}
		

	}
}
