using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroLivesUI : MonoBehaviour {

	private Text count;
	[SerializeField]
	private BushwickController player;
	private PlayerHealth health;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<BushwickController>();
		count = this.GetComponent<Text> ();
		health = player.GetComponent<PlayerHealth> ();
	}

	void Update(){
		count.text = "X " + health.GetLives ();
	}


}
