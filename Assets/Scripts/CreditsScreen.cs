using UnityEngine;
using System.Collections;

public class CreditsScreen : MonoBehaviour 
{
	void OnGUI()
	{	
		GUI.Label (new Rect (50, 10, 100, 100), "GameDevs");
		GUI.Label(new Rect(50,50,100,100),"Tom Verkerk\nDonovan Nguyen\nRob Verhoef\nDenzel Dap");
		GUI.Label (new Rect (180, 10, 100, 100), "Artists");
		GUI.Label (new Rect (180, 50, 100, 100), "Cerys Hancock\nIggy\nFendi Majoor\nCherelle Drenthe\n");
	}

}
