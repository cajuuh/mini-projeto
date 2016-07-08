using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public Transform Player;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, Player.position.y, -1);

    }

    // Update is called once per frame
    void Update () {
		transform.position = new Vector3 (0, Player.position.y, -1);
	}
}
