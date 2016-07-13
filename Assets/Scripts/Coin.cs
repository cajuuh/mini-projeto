using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Coin : MonoBehaviour {

	//Object variables
	public Transform PlayerCheck;
	public LayerMask Player;
	public GameObject coin;
	public AudioClip sfxCoin;

	//Primitive variables
	public bool isOverlaping;

	// Use this for initialization
	void Start () {
		isOverlaping = false;	
	}

	// Update is called once per frame
	void FixedUpdate () {
		GetACoin ();
	}

	void GetACoin(){
		if(isOverlaping){
			SoundManager.instance.PlaySingle (sfxCoin);
			coin.SetActive(false);
			Vector3 posicao = coin.transform.position;
			posicao.x = 4;
			coin.transform.position = posicao;
		}

		isOverlaping = Physics2D.OverlapCircle (PlayerCheck.position, 0.2f, Player);
				
	}
}
