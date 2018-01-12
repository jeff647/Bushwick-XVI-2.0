using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	private float health = 10f;
	[SerializeField]
	private float maxHealth = 0f;
	private float lives = 3f;
	private bool dead = true;

	// Use this for initialization
	void Start(){
		maxHealth = health;
	}
	public void AddHealth(float health){
		this.health += health;
		if (this.health > maxHealth) {
			this.health = maxHealth;
		}
	}
	public float GetLives(){
		return this.lives;
	}

	public float GetHealth(){
		return health;
	}
	public float GetMaxHealth(){
		return maxHealth;
	}
	void Update(){
		if ((health <= 0 && dead)) {
			gameObject.GetComponent<BushwickController> ().Death ();
			lives--;
			dead = false;
		}
			
	}
	public void Damage(int damage){
		this.health -= damage;
	}
}
