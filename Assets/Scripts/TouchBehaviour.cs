using UnityEngine;
using System.Collections;

public class TouchBehaviour : MonoBehaviour {

	private Vector2 touch;
	private Vector2 position;
	private int index;
	private float touchX;
	private float touchY;

	// Use this for initialization
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	public void touchInput () {
		touchX = (100/Screen.width)*Input.GetTouch(0).position.x;
		touchY = (100/Screen.height)*Input.GetTouch(0).position.y;
		position.x = -2.8f + 5.6f*(touchX/100);
		position.y = 5 - 10 * (touchY / 100);
		transform.position = position;
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
