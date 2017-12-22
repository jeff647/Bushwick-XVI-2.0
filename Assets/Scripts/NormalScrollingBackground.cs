using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalScrollingBackground : MonoBehaviour {
	[SerializeField]
	private float scrollSpeed;
	[SerializeField]
	private float endPointX;

	[SerializeField]
	private float repositionX;


	void Update () {
		Vector2 position = new Vector2 (transform.position.x - scrollSpeed * Time.deltaTime, transform.position.y);
		transform.position = position;

		if (transform.position.x <= endPointX)
			transform.position = new Vector2 (repositionX, transform.position.y);
	}
}
