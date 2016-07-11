using UnityEngine;
using System.Collections;

public class PlatformBehaviorScript : MonoBehaviour {

	//platform GameObjects
    public GameObject normalPlatform;
    public GameObject pontudaPlatform;
    public GameObject fragilPlatform;

    //get the Player GameObject
    [HideInInspector]
    public GameObject player;


    void Update()
    {
        ChangeTriggers();
    }

    private void ChangeTriggers()
    {
        if (Player.touchedNormal)
        {
            normalPlatform.GetComponent<Collider2D>().isTrigger = false;
        }
        else if (Player.touchedFragil)
        {
            fragilPlatform.GetComponent<Collider2D>().isTrigger = false;
        }
        else if (Player.touchedPontuda)
        {
            pontudaPlatform.GetComponent<Collider2D>().isTrigger = false;
        }
        else if (!(Player.touchedNormal))
        {
            normalPlatform.GetComponent<Collider2D>().isTrigger = true;
        }
        else if (!(Player.touchedFragil))
        {
            fragilPlatform.GetComponent<Collider2D>().isTrigger = true;
        }
        else if (!(Player.touchedPontuda))
        {
            pontudaPlatform.GetComponent<Collider2D>().isTrigger = true;
        }
    }


}
