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
    [HideInInspector]
    public GameObject spawn;


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
	[SerializeField] public GameObject retry;
	[SerializeField] public GameObject menu;

    void Start()
    {
        score = 0;
        SetText();
		retry.SetActive(false);
		menu.SetActive(false);
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
        SetText();

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
		retry.SetActive (true);
		menu.SetActive (true);
    }

	public void RestartGame(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void BackToMenu(){
		Application.LoadLevel ("Menu");
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

    }

    void SetText()
    {
        float pontos = score + spawn.GetComponent<SpawnPlataforma>().getPontuacao();
        scoreText.text = "Pontos: " + pontos;
    }
}

