using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	//Object variables
	public Transform PlayerCheck;
	public LayerMask Player;
	public GameObject coin;
	public AudioClip sfxCoin;

	//Primitive variables
	private bool isOverlaping;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if(isOverlaping){
			SoundManager.instance.PlaySingle (sfxCoin);
			Destroy (coin);
		}

		isOverlaping = Physics2D.OverlapCircle (PlayerCheck.position, 0.2f, Player);
	
	}
}
