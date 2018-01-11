using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Explode());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator Explode(){
		yield return new WaitForSeconds(2f);
		Vector3 position = this.transform.position;
		Collider2D[] targets = Physics2D.OverlapCircleAll (this.transform.position, 5f);
		foreach (Collider2D tar in targets) {
			
			if (tar.tag == "Enemy") {
				Debug.Log ("EXPLOSION");
				tar.GetComponentInParent<EnemyHealth> ().Damage (50);

			}
		}
		Destroy (gameObject,0.5f);

		yield break;
	}
}
