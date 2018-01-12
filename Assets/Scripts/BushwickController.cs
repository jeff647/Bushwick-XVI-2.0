using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BushwickController : MonoBehaviour {
    [SerializeField]
    float Speed = 5f;
    [SerializeField]
    float jumpForce = 650;
    [SerializeField]
    float fallMultiplier = 2.5f;
	[SerializeField]
	private GameObject grenade;
	[SerializeField]
	private float grenadeCount = 1f ;
	private AudioManager audio;
    private static GameObject player;

	private BushwickController playerControl;

	bool dead = false;

    bool facingRight = true;
    private Animator bushwickAnimation;
    private Rigidbody2D rigidBody;

    bool onGround = false;
    public Transform onGroundCheck;
    float onGroundRadius = 0.2f;
    public LayerMask IsGround;
	public float getGrenade(){
		return grenadeCount;
	}
    // Use this for initialization
    
    void Start() {
        
		audio = GameObject.Find ("_AudioManager").GetComponent<AudioManager> ();
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
			if (Input.GetKeyDown(KeyCode.F) && this.grenadeCount > 0f) {
				
				Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
				difference.Normalize ();
				float rotation_z = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

				GameObject p = Instantiate(grenade, this.transform.position, Quaternion.Euler (0f, 0f, rotation_z + -90f));
				p.GetComponent<Rigidbody2D> ().AddForce (p.transform.up * 1200f);
				grenadeCount--;
			}
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
            PlayerHealth h = this.transform.GetComponent<PlayerHealth>();
            h.Damage(5);

			
		} else if (col.tag == "nextLevel") {
			
		}
		if (col.tag == "GrenadeItem") {
			grenadeCount += 3f;
			Destroy (col.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "HealthItem") {
			PlayerHealth player = this.transform.GetComponent<PlayerHealth> ();
			player.AddHealth (1f);
			Destroy (col.gameObject);
		}

	}

	public void Death(){
		dead = true;
		bushwickAnimation.SetBool ("dead", dead);
		Debug.Log ("dead animation called");
		//Destroy (gameObject, 0.9f);
		//Invoke( "ChangeScene", 0.9f );
	}
	private void ChangeScene(){
		SceneManager.LoadScene ("MainMenu");
	}

}
