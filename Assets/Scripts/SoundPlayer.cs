using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer : MonoBehaviour{

	public List<AudioClip> Sounds = new List<AudioClip>();
	private AudioSource source;

	void Start(){
		source = GameObject.FindGameObjectWithTag ("SoundPlayer").GetComponent<AudioSource>();
	}

	public void playSound(int index){
		source.PlayOneShot (Sounds [index]);
	}
}