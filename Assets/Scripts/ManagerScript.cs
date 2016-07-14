using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManagerScript : MonoBehaviour
{
    //reference GameObjects hide in editor
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public GameObject camera;
    [HideInInspector]
    public GameObject coin;

    public Text debugText;

    //read only
    private readonly string PLAYER = "Player";
    private readonly string SOUND = "Sound";

    //text variable
    public Text scoreText;

    //prime variable
    public int score;

    //private variables
    private float duration = 1.0f;
    private float alpha = 1.0f;

    //panels
    [SerializeField] public GameObject gameOverPanel;

    void Start()
    {
        score = 0;
        SetText();
    }

    void Awake()
    {
        if (gameOverPanel.activeSelf)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        //follow the camera
        this.transform.position = camera.transform.position;

        //death and game over
        if (player.GetComponent<Player>().GetIsDead())
        {
            GameOver();
        }

        //TODO comment
        if (coin.GetComponent<Coin>().isOverlaping)
        {
            SetScore(10);
        }

    }

    void FixedUpdate()
    {
        CameraUnfollow();
    }

    /// <summary>
    /// if the velocity of the player is less than zero, the camera stop following his jumps
    /// and restarts following if the velocity becomes greater than zero.
    /// </summary>
    private void CameraUnfollow()
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

    public void GameOver()
    {
        GameObject.FindGameObjectWithTag(SOUND).SetActive(false);
        player.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == PLAYER)
        {
            GameOver();
        }
    }

    public void SetScore(int points)
    {
        score += points;
        SetText();

    }

    void SetText()
    {
        scoreText.text = "Pontos: " + score.ToString();
    }
}

