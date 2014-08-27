using UnityEngine;
using System.Collections;

public class TouchBehaviour : MonoBehaviour {

	private Vector2 touch;
	private int index;

	// Use this for initialization
	void Start () {
		index = 0;
		Input.multiTouchEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var T in Input.touches) {
			if(T.phase == TouchPhase.Moved){
				transform.position = T.position;
			}
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.transform.gameObject.GetComponent<PointScript>().indexNumber == index){
			//Change Target
			index++;
		}
		else{
			Application.LoadLevel("");
		}
	}
}
