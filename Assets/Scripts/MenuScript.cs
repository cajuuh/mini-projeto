using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	void OnGUI(){
		int width = 80;
		int height = 30;

		if (
			GUI.Button (
				new Rect (
					Screen.width / 2 - (width / 2),
					Screen.height / 2 - (height / 2),
					width,
					height),
				"START"
			)) {

			Application.LoadLevel ("Jumper");
		}
	}
}

