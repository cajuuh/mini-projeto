using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour
{
    //reference GameObjects hide in editor
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public GameObject camera;

    //read only
    private readonly string PLAYER = "Player";

    //panels
    public GameObject gameOverPanel;

    void Awake()
    {
        if (gameOverPanel.activeSelf)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            camera.GetComponent<MainCamera>().enabled = false;
        }
        else
        {
            camera.GetComponent<MainCamera>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == PLAYER)
        {
            Debug.Log("triggered!");
            Destroy(player.gameObject);
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
