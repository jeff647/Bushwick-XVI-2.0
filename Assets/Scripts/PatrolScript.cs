using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour {
	[SerializeField]
	private float speed;
	private bool isGoingLeft = true;
	[SerializeField]
	private bool isPatrolling = true;
	private bool isAttacking = false;
	private float yRotation = 180;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isGoingLeft && isPatrolling) {
			
			this.transform.position += Vector3.left * (speed * Time.deltaTime);
		} else if (!isGoingLeft && isPatrolling) {
			
			this.transform.position += Vector3.right * (speed * Time.deltaTime);
		} 


	}
	public float GetYRotation(){
		return yRotation;
	}
	public bool GetIsGoingLeft(){
		return isGoingLeft;
	}

	public void SetPatrolStatus(bool patrol){
		this.isPatrolling = patrol;
	}
	public void SetAttackStatus(bool attack){
		this.isAttacking = attack;
	}

	void OnTriggerExit2D(Collider2D col){
		//if (col.tag == "PatrolArea") {
			//Debug.Log ("collider hit");

			transform.Rotate (new Vector3 (0, yRotation * -1, 0));
			isGoingLeft = !isGoingLeft;
			Debug.Log ("collider hit: " + isGoingLeft);

				



		//}
	}
}
