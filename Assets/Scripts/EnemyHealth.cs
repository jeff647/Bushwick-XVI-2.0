using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[SerializeField]
	private int health = 2;
	// Use this for initialization

	void Update(){
		if (health <= 0)
			Destroy (gameObject);
	}
	public void Damage(int damage){
		this.health -= damage;
	}


}
