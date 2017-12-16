using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;

		
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//Lock ball relative to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//wait for mouse press to launch
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse clicked, launch ball");
				hasStarted = true;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 13f);
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.5f), Random.Range (0f, 0.5f));
		if (hasStarted) {
			GetComponent<AudioSource> ().Play();
			GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}

}


