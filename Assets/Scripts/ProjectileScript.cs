using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        coroutine = finish(1.5f);
        StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator finish(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
