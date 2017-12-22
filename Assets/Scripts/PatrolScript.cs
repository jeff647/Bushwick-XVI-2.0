using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour {
	[SerializeField]
	private float speed;
	[SerializeField]
	private bool stayStill = false;
	private bool isGoingLeft = true;
	private GameObject topParent;
	private bool isPatrolling = true;
	private float yRotation = 180;

	void Start () {
		topParent = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (stayStill == false) {
			if (isGoingLeft && isPatrolling) {
				topParent.transform.position += Vector3.left * (speed * Time.deltaTime);
			} else if (!isGoingLeft && isPatrolling) {
			
				topParent.transform.position += Vector3.right * (speed * Time.deltaTime);
			} 
		}


	}
	public bool GetStayStill(){
		return stayStill;
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

	void OnTriggerExit2D(Collider2D col){
		//if (col.tag != "Bullet" ) {
			
			if (!stayStill) {
				topParent.transform.Rotate (new Vector3 (0, yRotation * -1, 0));
				isGoingLeft = !isGoingLeft;
			}
			Debug.Log ("[PatrolScript] collider hit: " + isGoingLeft);

		//}
	
	}
}
