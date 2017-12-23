using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	[SerializeField]
	public Image content;

	// Private Variables
	private float _maxHealthVal;
	private float _healthValue;
	[SerializeField]
	private GameObject player;
	private PlayerHealth health;

	void Start(){
		//player = GameObject.Find ("Character");
		//content = GetComponent<Image>();
		health = player.GetComponent<PlayerHealth>();
		_maxHealthVal = health.GetMaxHealth ();
		_healthValue = health.GetHealth ();
		Debug.Log (_maxHealthVal + " " + _healthValue);


	}

	void Update(){
		_healthValue = health.GetHealth ();
		Debug.Log (_healthValue / _maxHealthVal);
		content.fillAmount = _healthValue / _maxHealthVal;
	}
}
