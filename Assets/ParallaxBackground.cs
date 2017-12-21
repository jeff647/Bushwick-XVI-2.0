using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {
	[SerializeField]
	private float parallaxSpeed;
	[SerializeField]
	private float lastCameraPosX;
	[SerializeField]
	private float backgroundSize;

	private Transform cameraTransform;
	private Transform[] layers;
	private float viewBuffer = 10;
	private int leftIndex;
	private int rightIndex;
	// Use this for initialization
	void Start () {
		
		cameraTransform = Camera.main.transform;
		lastCameraPosX = cameraTransform.position.x;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
			layers [i] = transform.GetChild (i);
		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
		//Controls the speed of the background.
		float cameraDeltaX = cameraTransform.position.x - lastCameraPosX;
		transform.position += Vector3.right * (cameraDeltaX * parallaxSpeed);
		//set last position of the camera.
		lastCameraPosX = cameraTransform.position.x;
		//If camera center is less than the left most Index [leftIndex, 0, rightIndex] + the viewBuffer length
		//the screens will treadmill to the left.
		if (cameraTransform.position.x < (layers [leftIndex].transform.position.x + viewBuffer))
			ScrollLeft ();
		//If camera center is more than the right most Index [leftIndex, 0, rightIndex] - the viewBuffer length
		//the screens will treadmill to the right.
		if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewBuffer))
			ScrollRight ();
		Debug.Log ("[" + leftIndex + ", " + rightIndex + "]");
	}

	private void ScrollLeft(){
		//calculates coordinates past the left most background Index position [leftIndex, 0, rightIndex].
		layers [rightIndex].position = Vector3.right * (layers [leftIndex].position.x - backgroundSize);
		//rotate tracked indexes (leftIndex/rightIndex). [2,1] -> [1,0] -> [0,2] -> [2,1]
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
			rightIndex = layers.Length - 1;
	}

	private void ScrollRight(){
		//positions the left most background Index [leftIndex, 0, rightIndex] to the right most Index.
		layers [leftIndex].position = Vector3.right * (layers [rightIndex].position.x + backgroundSize);
		//rotate tracked indexes (leftIndex/rightIndex). [0,2] -> [1,0] -> [2,1] -> [0,2]
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length )
			leftIndex = 0;
	}
}
