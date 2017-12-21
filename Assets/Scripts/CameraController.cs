using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;

    [SerializeField]
    float minX;
    [SerializeField]
    float maxX;
    [SerializeField]
    float minY;
    [SerializeField]
    float maxY;
    [SerializeField]
    float playerShift = 2f;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Clamp(player.transform.position.x, minX + playerShift, maxX);
        float y = Mathf.Clamp(player.transform.position.y, minY, maxY);
        gameObject.transform.position = new Vector3(x + playerShift, y, gameObject.transform.position.z);
    }
}
