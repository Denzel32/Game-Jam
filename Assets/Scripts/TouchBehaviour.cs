using UnityEngine;
using System.Collections;

public class TouchBehaviour : MonoBehaviour {

	private Vector2 touch;
	private Vector3 position;
	private int index;
	private float touchX;
	private float touchY;
	public GUIText text;

	// Use this for initialization
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	void Update(){
		touch = Input.GetTouch (0).position;
		touchX = 100 /Screen.width * touch.x;
		touchY = 100 /Screen.height *touch.y;
		Checkpos ();
		transform.position = position;
	}

	void Checkpos(){
		position.x = (5.6f*touchX) - 2.8f;
		position.y = (10 * touchY)-5;
		position.z = 3.7f;
		text.text = "1= " + touchX + "2= " + touchY;
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
