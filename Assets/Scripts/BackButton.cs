using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	void OnGUI () {
		
		GUI.Box(new Rect(10,10,100,40),"");
		
		if(GUI.Button(new Rect(20,20,80,20), "Back")) {
			Application.LoadLevel(0);
		}
		
	}
	
}
