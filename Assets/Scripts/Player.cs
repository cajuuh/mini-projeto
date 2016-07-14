using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Object variables
    [SerializeField]
	public Rigidbody2D 		PlayerRigidbody;
	public Animator 		Anime;
	public LayerMask 		ground;
	public Transform 		GroundCheck;
	public SpriteRenderer	sprite;


	//Primitive variables
    [SerializeField]
	private bool	isGrounded;
	private bool	flipped;
    private bool    isDead;
    private bool    isPontuda;
	public int		Speed;
	public int 		JumpHeight;

    //read only strings
    private readonly string ENEMY = "Chicken";
    private readonly string PONTUDA = "pontuda";

	void Start () {
		flipped = true;
	    isPontuda = false;
	}
		
	void FixedUpdate () {
		HowToMove ();
		HowToJump ();

        //added to make player wrap trough end of screen
        Physics2D.IgnoreLayerCollision(8,12,true);

        ControlLinearDrag();
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
		float velY = PlayerRigidbody.velocity.y;

		if (isGrounded && velY <= 0) {
			PlayerRigidbody.velocity = new Vector2 (0, 0);
			PlayerRigidbody.AddForce (new Vector2 (0, JumpHeight));

		}

		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, ground);

		Anime.SetBool ("jump", !isGrounded);
	}

    private void ControlLinearDrag()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.y > 6f)
        {
            this.GetComponent<Rigidbody2D>().drag = 1;
        }
        else
        {
            this.GetComponent<Rigidbody2D>().drag = 0;
        }
    }

    //private void DeathByPontuda()
    //{
    //    if(this.GetComponent<Collider2D>().IsTouching())
    //}

    public bool GetIsDead()
    {
        return isDead;
    }

}
