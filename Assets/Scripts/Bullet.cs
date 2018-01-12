using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private float force = 0.05f;
	[SerializeField]
	int damage = 1;

	void Start () {
		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector2.left * force * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PlayerHealth> ().Damage (damage);
		}
		if (col.gameObject.tag == "Ignore") {
			StartCoroutine (FlickerTrigger());
		} else {
			Destroy (gameObject);
		}


	}

	void OnTriggerEnter2D(Collider2D col){
		
	}
	private IEnumerator FlickerTrigger(){
		CircleCollider2D col = this.GetComponent<CircleCollider2D> ();
		col.isTrigger = true;
		yield return new WaitForSeconds (0.02f);
		col.isTrigger = false;
		yield break;
	}

}
