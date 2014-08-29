using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Randomize : MonoBehaviour {
	//publics
	public int levelCount = 10;
	public int pointAmount;
	public static List<GameObject> points = new List<GameObject>();
	public List<Texture2D> AncorPoints = new List<Texture2D> ();
	public int l;
	public string nextLevel;

	//privates
	private GameObject collisionPoint;
	private GameObject glow;
	private Vector3 touchPos = new Vector3();
	private bool touchEnabled = false;
	private bool began = false;
	private float[] coordinateX;
	private float[] coordinateY;
	//private int lvl = 3; 

	// Use this for initialization
	void Start () {
		l = 2;
		pointAmount = 10;
		Input.multiTouchEnabled = false;
		CreatePoints();
	}
	
	// Update is called once per frame
	void Update () {
		/*for (int i = 0; i < Input.touchCount) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

				if (Physics.Raycast(ray)) {
					Debug.Log("Test");
				}
			}
		}*/

		if (touchEnabled == true) {
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
				touchPos = Input.GetTouch(0).position;
				
				collisionPoint = (GameObject)Instantiate(Resources.Load("Prefabs/CollisionPoint"), Camera.main.ScreenToWorldPoint(touchPos), Quaternion.identity);
				began = true;
			}
			
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && began == true) {
				Destroy(collisionPoint);
				touchEnabled = false;
				began = false;
				if(collisionPoint.GetComponent<TouchBehaviour>().complete == false){

					Application.LoadLevel("GameOverScreen");
				}
			}
		}
	}

	public IEnumerator SimonSays () {
	//Redo: //Ugly scripting is necessary

		yield return new WaitForSeconds(1);

		
		if (l > pointAmount-6) {
				Application.LoadLevel(nextLevel);
			//l = 0;
		}

		for (int i = 0; i <= l; i++) {
			if(points[i].gameObject != null){
				//points[i].gameObject.renderer.material.color = Color.green;

				//yield return new WaitForSeconds(1);

				//points[i].gameObject.renderer.material.color = Color.gray;

				points[i].gameObject.GetComponentInChildren<GlowEffect>().on = true;

				yield return new WaitForSeconds(3.5f);
			}
			else{
				CreatePoints();
			}
		}

		//touch input
		
		l++;
		touchEnabled = true;

		//goto Redo; //Ugly scripting is necessary
	}

	private void CreatePoints () {
		coordinateX = new float[pointAmount];
		coordinateY = new float[pointAmount];
		points.Clear ();
		
		for (int i = 0; i < pointAmount; i++) {
			GameObject point;
			//Vector3 pos = UpdateLocation(-2.0f, 2.0f, -4.5f, 4.5f);
			Vector3 pos = UpdateLocation(-1.5f, 1.5f, -3f, 3f);
			point = (GameObject)Instantiate(Resources.Load("Prefabs/Point"), pos, Quaternion.identity);
			point.gameObject.renderer.material.mainTexture = AncorPoints[i];
			point.GetComponent<PointScript>().indexNumber = i;

			for (int j = 0; j < pointAmount; ++j) {
				if (coordinateX[j] <= pos.x + 1.0f && coordinateX[j] >= pos.x - 1.0f &&
				    coordinateY[j] <= pos.y + 1.0f && coordinateY[j] >= pos.y - 1.0f) {
					
					pos = UpdateLocation(-1.5f, 1.5f, -3f, 3f);
					j = 0;
				}
			}


			point.transform.position = pos;
			point.name = PointScript.pointName;
			coordinateX[i] = pos.x;
			coordinateY[i] = pos.y;
			
			points.Add(point);
		}
		StartCoroutine("SimonSays");
	}

	public void NextSet () {
		StopCoroutine("SimonSays");
		StartCoroutine("SimonSays");
	}

	public static Vector2 UpdateLocation (float minX, float maxX, float minY, float maxY) {
		Vector2 pos = new Vector2(0, 0);

		pos.x = Random.Range(minX, maxX);
		pos.y = Random.Range(minY, maxY);

		return pos;
	}
}