using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	public bool autoPlay = false;
	private Ball ball;
	public float minX = 0.5f;
	public float maxX = 15.5f;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
		
	}

	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX,maxX);
		this.transform.position = paddlePos;	
	}
}
