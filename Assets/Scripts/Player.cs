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

	// Use this for initialization
	void Start () {
		flipped = true;
	}

	// Update is called once per frame
	void Update (){
	}
		
	// For physics stuff
	void FixedUpdate () {

		//jump
		if(isGrounded){
			PlayerRigidbody.AddForce(new Vector2(0, JumpHeight));
		}

		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, ground);

		Anime.SetBool ("jump", !isGrounded);

		//move
		Vector3 move = new Vector3 (Input.GetAxis("Horizontal"), 0 , 0);
		transform.position += move * Speed * Time.deltaTime;

		//flip
		if(move.x > 0 && !flipped || move.x < 0 && flipped){
			flipped = !flipped;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;

		}

		//wrap

	}

}
