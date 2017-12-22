using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour {
	[SerializeField]
	private float fireRate = 2f;
	
	private float coolDown = 0f;
	[SerializeField]
	private float offset;
	private GameObject playerObject = null;
	[SerializeField]
	private GameObject bulletPrefab;
	private Transform gunMuzzle;
	private PatrolScript patrol;
	private Quaternion initialRotation;


	void Start () {
		gunMuzzle = gameObject.transform.GetChild (0);
		patrol = GetComponentInParent<PatrolScript> ();
		initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerObject != null) {
			
			Vector3 difference = playerObject.transform.position - transform.position;
			difference.Normalize ();
			float rotation_z = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0f, 0f, rotation_z + offset);
			if (Time.time > coolDown) {
				GameObject b = Instantiate (bulletPrefab, gunMuzzle.position, this.transform.rotation) as GameObject;
				coolDown = Time.time + fireRate;
			}
		} 
	}

	public void SetPlayerTarget(GameObject obj){
		this.playerObject = obj;
	}
}
