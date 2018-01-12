using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[SerializeField]
	private int health = 2;
	[SerializeField]
	private GameObject dropItem;
	// Use this for initialization

	void Update(){
		if (health <= 0) {
			if (Random.Range (1, 10) <= 3) {
				Instantiate (dropItem, this.transform.position, Quaternion.identity);
			}
			Destroy (gameObject);
		}
	}
	public void Damage(int damage){
		this.health -= damage;
	}


}
