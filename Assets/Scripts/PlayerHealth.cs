using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    
	[SerializeField]
	private float health = 10f;
	[SerializeField]
	private float maxHealth = 0f;
    [SerializeField]
	private float lives = 3f;
	private bool dead = false;
    [SerializeField]
    private GameObject RespawnPoint;
    private bool isDying = false;

	// Use this for initialization
	void Start(){
		maxHealth = health;
	}
	public void AddHealth(float health){
		this.health += health;
		if (this.health > maxHealth) {
			this.health = maxHealth;
		}
	}
	public float GetLives(){
		return this.lives;
	}

	public float GetHealth(){
		return health;
	}
	public float GetMaxHealth(){
		return maxHealth;
	}
   

    void Update(){

        if(this.health <= 0f )
        {
            if(this.lives <= 0f)
            {
                Invoke("ChangeScene", 0.9f);
            }
            this.dead = true;
            Debug.Log("YO DEAD" + lives + " " + dead);
            if (this.lives > 0f && !isDying)
            {
                isDying = true;
                this.lives--;
                //Respawn to pointS
                Vector2 pos = RespawnPoint.transform.position;
                this.health = maxHealth;
                this.gameObject.transform.position = pos;



            }
            else if (this.lives == 0f && this.dead)
            {
                gameObject.GetComponent<BushwickController>().Death();
                Invoke("ChangeScene", 0.9f);
            }
            
            isDying = false;
    }

		
			
	}
	public void Damage(int damage){
		this.health -= damage;
        if(this.health < 0)
        {
            this.health = 0;
        }
	}
    private void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
