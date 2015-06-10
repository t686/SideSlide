using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public static int PLAYER_COMBO = 0;	//TODO: Combo counter;

	public float maxSpeed = 10f;		// The fastest the player can travel in the x axis.
	public float moveForce = 50f;		// Amount of force added to move the player left and right.
	public float jumpForce = 150f;		// Amount of force added when the player jumps.

	public float rotSpeed = 10.0f;		// Spee
	private float angle = -90.0f;		
	
	private int countJump = 0;

	public bool isGrounded = false;		// Whether or not the player is grounded.


	//References
	private Animator anim;
	private Rigidbody2D rb2d;

	void Start(){
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		//anim = gameObject.GetComponent<Animator>():
		//rotVect = new Vector3(0, 0, angle);
	}
	
	void Update(){
		if(Input.GetButtonDown("Jump") && isGrounded) { 
			rb2d.AddForce(new Vector2(0, jumpForce));
			IncrementAngle();
			countJump += 1;
		} else if(Input.GetButtonDown("Jump") && countJump<2) {
			countJump += 1;
			IncrementAngle();
		}

		if(!isGrounded) {
			Rotate ();
		}

	}
	
	
	void FixedUpdate (){

		float h = Input.GetAxis("Horizontal");

		if(isGrounded && countJump > 0) {
			countJump = 0;
		} 


		rb2d.AddForce(Vector2.right * h * moveForce);
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rb2d.velocity.x) > maxSpeed){
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}
	}


	void Rotate() {

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotSpeed*Time.deltaTime);
	
	}

	void IncrementAngle() {

		angle += -90.0f;

	}
}
