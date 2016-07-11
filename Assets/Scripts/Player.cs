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

    //static variables
    public static bool touchedFragil;
    public static bool touchedNormal;
    public static bool touchedPontuda;

    //read only strings
    private readonly string FRAGIL = "fragil";
    private readonly string NORMAL = "normal";
    private readonly string PONTUDA = "pontuda";

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
		if (isGrounded) {
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        this.GetComponent<Collider2D>().isTrigger = true;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        this.GetComponent<Collider2D>().isTrigger = false;
    }


    void OnCollisionExit2D(Collision2D coll)
    {
        this.GetComponent<Collider2D>().isTrigger = false;
    }
}
