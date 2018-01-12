using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	private AudioSource grenade;
	private AudioSource gun;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		AudioSource[] audio = this.transform.GetComponents<AudioSource>();
		grenade = audio [2];
		gun = audio [1];

	}
	
	public void PlayGun(){
		gun.Play ();
	}
	public void PlayBoom(){
		grenade.Play ();
	}
}
