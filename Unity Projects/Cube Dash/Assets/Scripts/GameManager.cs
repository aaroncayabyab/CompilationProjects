using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	public GameObject completeLevelUI;

	public void CompleteLevel() {
		completeLevelUI.SetActive (true);
	}

	public void EndGame() {

		if (gameHasEnded == false) {
			gameHasEnded = true;
			Debug.Log ("HI");		

			//Restart game
			Invoke("Restart", 1f);
		}

	}

	void Restart() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Quit() {
		Debug.Log ("Exit Game");
		Application.Quit ();
	}

	public void StartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void Replay() {
		SceneManager.LoadScene ("Menu");
	}


}
