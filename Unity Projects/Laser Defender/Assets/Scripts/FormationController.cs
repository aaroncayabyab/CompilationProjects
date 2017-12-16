using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed=5f;
	public float spawnDelay = 0.5f;

	private bool movingRight = false;
	private float xMin, xMax;


	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceToCamera));

		xMax = rightBoundary.x;
		xMin = leftBoundary.x;

		SpawnUntilFull ();

	}

	void SpawnEnemies() {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;			
		}
	}

	void SpawnUntilFull() {
		Transform freePosition = NextFreePosition ();

		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;	
		}
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update () {

		if (movingRight) {
			transform.position += new Vector3 (speed * Time.deltaTime, 0);
		} else {
			transform.position += new Vector3 (-speed * Time.deltaTime, 0);	
		}

		float rightEdgeFormation = transform.position.x + (0.5f * width);
		float leftEdgeFormation = transform.position.x - (0.5f * width);		

		if (leftEdgeFormation < xMin) {
			movingRight = true;
		} else if (rightEdgeFormation > xMax) {
			movingRight = false;
		}

		if (AllMembersDead ()) {
			Debug.Log ("DEAD");
			SpawnUntilFull ();
		}
	}

	Transform NextFreePosition(){
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead(){
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}

