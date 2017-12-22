using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	private int health = 3;
	private bool dead = true;

	// Use this for initialization

	void Update(){
		if ((health <= 0 && dead)) {
			gameObject.GetComponent<BushwickController> ().Death ();
			dead = false;
		}
			
	}
	public void Damage(int damage){
		this.health -= damage;
	}
}
