using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour {

	public Transform player;

	Vector3 offset = new Vector3 (0, 2f, -5f);
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}
