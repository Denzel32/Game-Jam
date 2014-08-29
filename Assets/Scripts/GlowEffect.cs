using UnityEngine;
using System.Collections;

public class GlowEffect : MonoBehaviour {

	public bool on;
	public Vector3 glowSpeed;
	private bool back = false;
	private Vector3 Scale;

	// Use this for initialization
	void Update(){
		if(on == true){
			if(back == false){
				Scale += glowSpeed;
				if(Scale.x > 2.5f){
					back = true;
				}
			}
			if(back == true){
				Scale -= glowSpeed;
				if(Scale.x <= 0){
					on = false;
					back = false;
				}
			}
			transform.localScale = Scale;
		}
	}
}
