using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[SerializeField]
	private float health;
	// Use this for initialization

	void Update(){
		if (health <= 0)
			Destroy (gameObject);
	}
	public void SetDamage(float damage){
		this.health -= damage;
	}


}
