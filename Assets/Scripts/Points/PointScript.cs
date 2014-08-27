using UnityEngine;
using System.Collections;

public class PointScript : MonoBehaviour {

	public static string pointName = "Point";
	public int indexNumber = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter (Collision col) {
		if (col.collider.name == pointName) {
			gameObject.transform.position = Randomize.UpdateLocation(-2.0f, 2.0f, -4.5f, 4.5f);
			gameObject.renderer.material.color = Color.cyan;

			Debug.Log("Transformed");
		}
	}
}
