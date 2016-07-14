using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManagerScript : MonoBehaviour
{
    //reference GameObjects hide in editor
    [HideInInspector] public GameObject player;
    [HideInInspector] public GameObject camera;
    [HideInInspector] public GameObject coin;
    public GameObject fragilPlatform;

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

        StartCoroutine(FadeFragil(1.0f, 1.0f));
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
        player.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == PLAYER)
        {
            GameOver();
            GameObject.FindGameObjectWithTag(SOUND).SetActive(false);
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



    //void lerpAlpha()
    //{
    //    float lerp = Mathf.PingPong(Time.time, duration)/duration;
    //    alpha = Mathf.Lerp(0.0f, 1.0f, lerp);
    //    fragilPlatform.GetComponent<SpriteRenderer>().color.a -= alpha;
    //}

    /// <summary>
    /// Fade out the platform within the player
    /// </summary>
    /// <param name="aValue">amount of fade</param>
    /// <param name="aTime">time lapse'till total fade</param>
    /// <returns>null in yield</returns>
    IEnumerator FadeFragil(float aValue, float aTime)
    {
        float alpha = fragilPlatform.GetComponent<SpriteRenderer>().color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime/aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue, t));
            fragilPlatform.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }
}

