using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    //variables
    public float moveSpeed;
    public float curveSpeed;
    //private variables
    private float fTime = 0f;
    //vectors
    private Vector3 vLastPos = Vector3.zero;

    void Start()
    {
        fTime = 0f;
        vLastPos = transform.position;
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

        transform.position += (vSin + vLin) * Time.deltaTime;

        Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
    }

    void OnCollisionEnter2D(Collider2D col)
    {
        if (col.tag == "EndOfScreen")
        {
            Debug.Log("Bateu");
            ;
        }
    }






}
