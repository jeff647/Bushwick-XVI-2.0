using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {
	[SerializeField]
	private string scene;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			SceneManager.LoadScene (scene);
		}
	}
}
