using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    private IEnumerator coroutine;
	[SerializeField]
	int damage = 1;

	// Use this for initialization
	void Start () {
        coroutine = finish(1.5f);
        StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyHealth> ().Damage (damage);
		}
		Destroy (gameObject);
	}

    private IEnumerator finish(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
