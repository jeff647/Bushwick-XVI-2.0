using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private float force = 0.05f;
	[SerializeField]
	private float damage;

	void Start () {
		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector2.left * force * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){

	}
}
