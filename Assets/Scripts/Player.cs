using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Object variables
	public Rigidbody2D 		PlayerRigidbody;
	public Animator 		Anime;
	public LayerMask 		ground;
	public Transform 		GroundCheck;
	public SpriteRenderer	sprite;

	//Primitive variables
	private bool	isGrounded;
	private bool	flipped;
	public int		Speed;
	public int 		JumpHeight;

	void Start () {
		flipped = true;

	}

	void Update (){

	}
		
	void FixedUpdate () {
		HowToMove ();
		HowToJump ();

        //added to make player wrap trough end of screen
        Physics2D.IgnoreLayerCollision(8,12,true);
	    ;
	}


	void HowToMove (){
		//move
		Vector3 move = new Vector3 (Input.GetAxis("Horizontal"), 0 , 0);
		transform.position += move * Speed * Time.deltaTime;

		//flip while moving
		if(move.x > 0 && !flipped || move.x < 0 && flipped){
			flipped = !flipped;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;

		}
	}

	void HowToJump (){
		if(isGrounded)	PlayerRigidbody.AddForce(new Vector2(0, JumpHeight));

		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, ground);

		Anime.SetBool ("jump", !isGrounded);
	}
}
