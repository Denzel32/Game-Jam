using UnityEngine;
using System.Collections;

public class TouchBehaviour : MonoBehaviour {

	private Vector2 touch;
	private Vector3 position;
	private int index;
	private float touchX;
	private float touchY;
	private SoundPlayer soundPlayer;
	private Randomize Randomize;
	private int random;
	private int points;

	// Use this for initialization
	void Start () {
		index = 0;
		points = 0;
		soundPlayer = gameObject.GetComponent<SoundPlayer>();
		Randomize = GameObject.FindWithTag ("MainCamera").GetComponent<Randomize> ();
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
		position.z = 0;
		}

	void OnCollisionEnter(Collision col){
		if(col.transform.gameObject.GetComponent<PointScript>().indexNumber == index){
			random = Random.Range(0,soundPlayer.Sounds.Count);
			soundPlayer.playSound(random);
			if(index == Randomize.l){
				Randomize.NextSet();
			}
			else{
				index++;
			}
		}
		else{
			Application.LoadLevel("Menuscreen");
		}

	}
}