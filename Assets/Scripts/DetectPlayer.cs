using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

	private RotateArm rotateArm;
	private PatrolScript patrol;
	void Start () {
		rotateArm = transform.parent.GetComponentInChildren<RotateArm> ();
		patrol = transform.parent.GetComponentInChildren<PatrolScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
//			if (col.transform.position.x > transform.parent.position.x) {
//				if(patrol.GetIsGoingLeft())
//					transform.parent.Rotate(new Vector3(0,(patrol.GetYRotation() * -1),0));
//			} else if (col.transform.position.x < transform.parent.position.x) {
//				if(!patrol.GetIsGoingLeft())
//					transform.parent.Rotate(new Vector3(0,(patrol.GetYRotation() * -1),0));
//			}
			rotateArm.SetPlayerTarget (col.gameObject);
			patrol.SetPatrolStatus (false);
		}
	}

	void OnTriggerStay2D(Collider2D col){

	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			
				patrol.SetPatrolStatus (true);
				rotateArm.SetPlayerTarget (null);
				Debug.Log ("[DetectPlayer] Enemy direction: " + patrol.GetIsGoingLeft ());
			}

	}
}
