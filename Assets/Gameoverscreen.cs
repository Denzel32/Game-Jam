using UnityEngine;
using System.Collections;

public class Gameoverscreen : MonoBehaviour {

	private float i;

	// Use this for initialization
	void Update () {
		i++;
		if (i > 500 || Input.touchCount > 0) {
						Application.LoadLevel ("Menuscreen");
				}
	}
}
