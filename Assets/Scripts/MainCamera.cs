using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public Transform Player;
    public Transform endOfScreen;

    // Use this for initialization
    void Start()
    {
    }
    void Update()
    {
        transform.position = new Vector3(0, Player.position.y, -1);
        endOfScreen.transform.position = new Vector3(0, Player.position.y, 0);
        //mantem o fim da tela junto ao player e a camera        
    }
   }
