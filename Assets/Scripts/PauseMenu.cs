using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	[SerializeField]
	private GameObject pauseMenu;
	private bool isActive = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			isActive = !isActive;
			pauseMenu.SetActive(isActive);
			if (isActive)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	}
}
