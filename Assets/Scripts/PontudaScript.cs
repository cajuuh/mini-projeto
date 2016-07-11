using UnityEngine;
using System.Collections;

public class PontudaScript : MonoBehaviour
{

    private readonly string PLAYER = "Player";

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == PLAYER)
        {
            Destroy(this.gameObject);
        }
    }
}
