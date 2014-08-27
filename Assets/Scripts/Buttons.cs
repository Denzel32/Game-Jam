using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	void OnGUI () {

		GUI.Box(new Rect(110,10,100,180),"Menu");

		if(GUI.Button(new Rect(120,40,80,20), "Start")) {
			Application.LoadLevel("GameScene1");
		}

		if(GUI.Button(new Rect(120,70,80,20), "Options")) {
			//Application.LoadLevel(1);
		}

		if(GUI.Button(new Rect(120,100,80,20), "Help")) {
			Application.LoadLevel("Helpscreen");
		}

		if(GUI.Button(new Rect(120,130,80,20), "Credits")) {
			Application.LoadLevel("Creditscreen");
		}

		if(GUI.Button(new Rect(120,160,80,20), "Exit")) {
			Application.Quit();
		}
	
	}
}
