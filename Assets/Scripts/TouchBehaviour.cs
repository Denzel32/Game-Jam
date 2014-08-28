using UnityEngine;
using System.Collections;

public class TouchBehaviour : MonoBehaviour {

	private Vector2 touch;
	private Vector3 position;
	private int index;
	private float touchX;
	private float touchY;

	// Use this for initialization
	void Start () {
		index = 0;
	}

	// Update is called once per frame
	void Update(){
		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0).position;
			touchX = touch.x / Screen.width * 100;
			touchY = touch.y / Screen.height * 100;
			Checkpos ();
			gameObject.transform.position = position;
		}
	}

	void Checkpos(){
		position.x = ((5.6f*touchX)/100) - 2.8f;
		position.y = ((10 * touchY)/100)-5;
		position.z = 3.7f;
		}

	void OnCollisionEnter(Collision col){
		if(col.transform.gameObject.GetComponent<PointScript>().indexNumber == index){
			//Change Target
			index++;
		}
		else{
			Application.LoadLevel("Menuscreen");
		}
	}
}
