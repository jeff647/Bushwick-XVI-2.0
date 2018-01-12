using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeUI : MonoBehaviour {

	private Text count;
	[SerializeField]
	private BushwickController player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<BushwickController>();
		count = this.GetComponent<Text> ();

	}

	void Update(){
		count.text = "X " + player.getGrenade ();
	}
	

}
