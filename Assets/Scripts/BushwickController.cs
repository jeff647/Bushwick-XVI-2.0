using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushwickController : MonoBehaviour {
    [SerializeField]
    float Speed = 5f;
    [SerializeField]
    float jumpForce = 650;
    [SerializeField]
    float fallMultiplier = 2.5f;

	private BushwickController playerControl;

	bool dead = false;

    bool facingRight = true;
    private Animator bushwickAnimation;
    private Rigidbody2D rigidBody;

    bool onGround = false;
    public Transform onGroundCheck;
    float onGroundRadius = 0.2f;
    public LayerMask IsGround;

    // Use this for initialization
    void Start() {
        bushwickAnimation = GetComponent<Animator>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    //From https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-character-controllers and Blackboard content
    void FixedUpdate() {
		if(!dead){
	        onGround = Physics2D.OverlapCircle(onGroundCheck.position, onGroundRadius, IsGround);
	        bushwickAnimation.SetBool("Ground", onGround);

	        float userMove = Input.GetAxis("Horizontal");
	        bushwickAnimation.SetFloat("Speed", Mathf.Abs(userMove));

	        rigidBody.velocity = new Vector2(userMove * Speed, rigidBody.velocity.y);

	        if (rigidBody.velocity.x > 0)
	        {
	            gameObject.transform.localScale = new Vector3(1, 1, 1);
	        }
	        else if (rigidBody.velocity.x < 0)
	        {
	            gameObject.transform.localScale = new Vector3(-1, 1, 1);
	        }
    	}
	}

    void Update()
	{
		if (!dead) {    
			if (onGround && Input.GetButtonDown ("Jump")) {
				bushwickAnimation.SetBool ("Ground", false);
				rigidBody.AddForce (new Vector2 (0, jumpForce));
			}

			//When falling fall down faster From https://www.youtube.com/watch?v=7KiK0Aqtmzc
			if (!onGround && rigidBody.velocity.y < 0) {
				rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			}
		}
	}
    //From https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-character-controllers and Blackboard content

	public void OnTriggerEnter2D(Collider2D col){
		bushwickAnimation.SetBool ("Ground", true);
		if (col.tag == "Kill Line") {

			Death ();
		} else if (col.tag == "nextLevel") {
			Debug.Log ("Level complete");
		}
	}

	public void Death(){
		dead = true;
		bushwickAnimation.SetBool ("dead", dead);
		Debug.Log ("dead animation called");
		Destroy (gameObject, 0.9f);
	}

}
