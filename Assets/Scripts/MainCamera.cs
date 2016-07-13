using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public Transform Player;
    public Transform endOfScreen;

    private Vector3 specificVector = new Vector3(0,0,0);

    public int smooth;

	// Use this for initialization
	void Start ()
	{
	    smooth = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {

        //smooth follow
        specificVector = new Vector3(0, Player.position.y, -1);
        this.transform.position = Vector3.Lerp(this.transform.position, specificVector, smooth * Time.deltaTime);

        //transform.position = new Vector3 (0, Player.position.y, -1);
        endOfScreen.transform.position = new Vector3(0, Player.position.y, 0);
        //mantem o fim da tela junto ao player e a camera        
    }
}
