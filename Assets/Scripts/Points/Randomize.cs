using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Randomize : MonoBehaviour {
	//publics
	public int levelCount = 7;
	public int pointAmount = 10;

	//privates
	public static List<GameObject> points = new List<GameObject>();
	private float[] coordinateX;
	private float[] coordinateY;
	
	// Use this for initialization
	void Start () {
		CreatePoints();

		StartCoroutine("SimonSays");
		//StopCoroutine("SimonSays");
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
	}

	private IEnumerator SimonSays () {
		int l = 3;

		for (int i = 0; i < l; i++) {
			points[i].gameObject.renderer.material.color = Color.green;

			yield return new WaitForSeconds(0.5f);

			points[i].gameObject.renderer.material.color = Color.gray;

			if (l > pointAmount) {
				l = 0;

				/*for (int lvl = 0; lvl < levelCount; lvl++) {
					Application.LoadLevel(lvl);
				}*/
			}

			l++;

			yield return new WaitForSeconds(1.5f);
		}
	}

	private void CreatePoints () {
		coordinateX = new float[pointAmount];
		coordinateY = new float[pointAmount];
		
		for (int i = 0; i < pointAmount; i++) {
			GameObject point;
			Vector3 pos = UpdateLocation(-2.0f, 2.0f, -4.5f, 4.5f);
			//int k = 0;
			
			point = (GameObject)Instantiate(Resources.Load("Prefabs/Point"), pos, Quaternion.identity);
			
			for (int j = 0; j < pointAmount; ++j) {
				if (coordinateX[j] <= pos.x + 1.0f && coordinateX[j] >= pos.x - 1.0f &&
				    coordinateY[j] <= pos.y + 1.0f && coordinateY[j] >= pos.y - 1.0f) {
					
					pos = UpdateLocation(-2.0f, 2.0f, -4.5f, 4.5f);
					j = 0;
				}
			}
			
			point.transform.position = pos;
			point.name = PointScript.pointName;
			coordinateX[i] = pos.x;
			coordinateY[i] = pos.y;
			
			points.Add(point);
		}
	}

	public static Vector2 UpdateLocation (float minX, float maxX, float minY, float maxY) {
		Vector2 pos = new Vector2(0, 0);

		pos.x = Random.Range(minX, maxX);
		pos.y = Random.Range(minY, maxY);

		return pos;
	}
}