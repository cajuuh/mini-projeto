using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public Transform PlayerCheck;
	public bool isOverlaping;
	public LayerMask Player;
	public GameObject coin;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {


		if(isOverlaping){
            coin.SetActive(false) ;
		}

		isOverlaping = Physics2D.OverlapCircle (PlayerCheck.position, 0.2f, Player);
	
	}
}
