﻿using UnityEngine;
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
    private bool fromBellow; //used to set if player is comming from below on PONTUDA
    private bool onFragil;

    private Gyroscope control;

	public int		Speed;
	public int 		JumpHeight;

    //read only strings
    private readonly string ENEMY = "Chicken";
    private readonly string PONTUDA = "pontuda";
    private readonly string FRAGIL = "fragil";

	void Start () {
		flipped = true;
	    isPontuda = false;
        control.enabled = true;
    }
		
	void FixedUpdate () {
		HowToMove ();
		HowToJump ();

        //added to make player wrap trough end of screen
        //TODO change those magic numbers
        Physics2D.IgnoreLayerCollision(8,12,true);

        ControlLinearDrag();
    }


	void HowToMove (){
        //move
        //Vector3 move = new Vector3 (Input.GetAxis("Horizontal"), 0 , 0);
        Vector3 move = new Vector3(control.rotationRate.y, 0, 0);
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

    public bool GetOnFragil()
    {
        return onFragil;
    }

    public void SetOnFragil(bool fragil)
    {
        onFragil = fragil;
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == FRAGIL)
        {
            onFragil = true;
        }
        if(coll.gameObject.tag == PONTUDA && coll.contacts.Length > 0)
        {
            ContactPoint2D contact = coll.contacts[0];
            if (Vector2.Dot(contact.normal, Vector2.up) > 0.5)
            {
                fromBellow = true;
            }
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == ENEMY)
        {
            isDead = true;
        }
        if (coll.gameObject.tag == FRAGIL)
        {
            onFragil = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == PONTUDA && fromBellow)
        {
            isDead = true;
        }

        if (coll.gameObject.tag == FRAGIL)
        {
            onFragil = true;
        }
    }
}
