using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void ChangeScene(string name){
		SceneManager.LoadScene (name);
	}
	public void ExitApplication(){
		Application.Quit ();
	}
}
