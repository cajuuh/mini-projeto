using UnityEngine;
using System.Collections;

public class BehaviorFragilScript : MonoBehaviour
{

    private GameObject player;

    //readonly asignments
    private readonly string PLAYER = "Player";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYER);
    }

    void Update()
    { 
        if (player.GetComponent<Collider2D>().IsTouching(this.GetComponent<Collider2D>()))
        {
            StartCoroutine(FadeFragil(0.0f, 1.0f));
        }
    }

    /// <summary>
    /// Fade out the platform within the player
    /// </summary>
    /// <param name="aValue">amount of fade</param>
    /// <param name="aTime">time lapse'till total fade</param>
    /// <returns>null in yield</returns>
    IEnumerator FadeFragil(float aValue, float aTime)
    {
        float alpha = this.GetComponent<SpriteRenderer>().color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            this.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
        this.gameObject.SetActive(false);
        ;
    }
}
