using System;
using UnityEngine;
using System.Collections;
using System.Runtime.ConstrainedExecution;

public class Enemy : MonoBehaviour
{
	//Object variables
	public AudioClip sfxChicken;

	//prime variables
    public float moveSpeed;
    public float curveSpeed;

    //private prime varaiables
    private float fTime = 0f;
    private bool flipped;

    //vectors
    private Vector3 vLastPos = Vector3.zero;

    //read only
    private readonly string END_OF_SCREEN = "EndOfScreen";

    void Start()
    {
        vLastPos = transform.position;
        flipped = false;
    }

    void Update()
    {
        SineMovement();
    }

    private void SineMovement()
    {
        vLastPos = transform.position;

        fTime += Time.deltaTime * curveSpeed;

        Vector3 vSin = new Vector3(Mathf.Sin(fTime), -Mathf.Sin(fTime), 0);
        Vector3 vLin = new Vector3(-moveSpeed, 0, 0);
        if (flipped)
        {
            vSin *= -1;
            vLin *= -1;
        }

        transform.position += (vSin + vLin) * Time.deltaTime;


        //draw a line if you need to see the sin
        //Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == END_OF_SCREEN)
        {
            flipped = !flipped;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
