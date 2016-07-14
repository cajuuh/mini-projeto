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

    //read only
    private readonly string PLAYER = "Player";

	//text variable
	public Text scoreText;

	//prime variable
	public int score; 

    //panels
    [SerializeField]
    public GameObject gameOverPanel;

	void Start()
	{
		score = 0;
		setText ();
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

        if (player.GetComponent<Player>().GetIsDead())
        {
            GameOver();
        }

		if(coin.GetComponent<Coin>().isOverlaping){
			SetScore (10);	
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

	public void SetScore(int points){
		score += points;
		setText ();

	}

	void setText(){
		scoreText.text = "Pontos: " + score.ToString ();
	}
}

