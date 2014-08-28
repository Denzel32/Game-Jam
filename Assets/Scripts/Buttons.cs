using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	void OnGUI () {

		GUI.Box(new Rect(Screen.width*0.1f,Screen.height*0.1f,Screen.width*0.8f,Screen.height*0.8f),"Menu");

		if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.15f,Screen.width*0.6f,Screen.height*0.1f), "Start")) {
			Application.LoadLevel(1);
		}

		if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.275f,Screen.width*0.6f,Screen.height*0.1f), "Options")) {
			//Application.LoadLevel(1);
		}

		if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.4f,Screen.width*0.6f,Screen.height*0.1f), "Help")) {
			Application.LoadLevel(2);
		}

		if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.525f,Screen.width*0.6f,Screen.height*0.1f), "Credits")) {
			Application.LoadLevel(3);
		}

		if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.65f,Screen.width*0.6f,Screen.height*0.1f), "Exit")) {
			Application.Quit();
		}
	
	}
}
