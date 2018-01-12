using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResumeButton : MonoBehaviour {
	[SerializeField]
	private GameObject parent;
	public void UnPause(){
		parent.SetActive (false);
		Time.timeScale = 1;
		PauseMenu pause = Camera.main.GetComponent<PauseMenu> ();
		if (pause.IsActive) {
			pause.IsActive = false;
		}
	}
	public void ExitToMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
}
