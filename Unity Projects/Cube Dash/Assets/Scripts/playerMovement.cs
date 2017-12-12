using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public Rigidbody player;
	public float travelSpeed = 2000f;
	public float controlSpeed = 120f;
	
	// Update is called once per frame
	void FixedUpdate () {
		player.AddForce (0, 0, travelSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			player.AddForce (controlSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			player.AddForce (-controlSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (player.position.y < -1f) {
			FindObjectOfType<GameManager> ().EndGame();
		}
		
	}
}
