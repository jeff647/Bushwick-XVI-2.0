using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour {

	[SerializeField]
	private GameObject explosionPrefab;
	[SerializeField]
	private float radius = 3f;

	// Use this for initialization
	void Start () {
		StartCoroutine (IgnoreCharacter ());
		StartCoroutine (Explode());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator Explode(){
		yield return new WaitForSeconds(2f);
		Vector3 position = this.transform.position;
		Collider2D[] targets = Physics2D.OverlapCircleAll (this.transform.position, radius);
		foreach (Collider2D tar in targets) {
			
			if (tar.tag == "Enemy") {				
				tar.GetComponentInParent<EnemyHealth> ().Damage (50);
			}
		}
		GameObject explosion = Instantiate(explosionPrefab,this.transform.position,Quaternion.identity) as GameObject;
		Destroy (explosion, 0.5f);
		Destroy (this.gameObject);

		yield break;
	}

	private IEnumerator IgnoreCharacter(){
		CircleCollider2D col = this.GetComponent<CircleCollider2D> ();
		col.isTrigger = true;
		yield return new WaitForSeconds (0.02f);
		col.isTrigger = false;
		yield break;
	}
}
