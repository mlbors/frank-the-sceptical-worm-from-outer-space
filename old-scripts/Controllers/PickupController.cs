/**
 * FTSWFOS - PickupController.cs
 *
 * @since       22.05.2017
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************/
/**************************************************/

/**********************/
/***** CONTROLLER *****/
/**********************/

public class PickupController : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public int scoreToGive;

	//PRIVATE
	//-------

	private ScoreManager scoreManager;

	private AudioSource coinSound;

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {
		this.setValues ();
	}
	
	/**************************************************/
	/**************************************************/

	/******************/
	/***** UPDATE *****/
	/******************/

	void Update () {
		
	}

	/**************************************************/
	/**************************************************/

	/*******************/
	/***** SETTERS *****/
	/*******************/

	/*****/
	/***** SET VALUES *****/
	/*****/

	private void setValues () {
		this.setScoreManager ();
		this.setCoinSound ();
	}

	/*****/
	/***** SCORE MANAGER *****/
	/*****/

	private void setScoreManager () {
		this.scoreManager = FindObjectOfType<ScoreManager> ();
	}

	/*****/
	/***** SCORE MANAGER *****/
	/*****/

	private void setCoinSound () {
		this.coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource> ();
	}

	/**************************************************/
	/**************************************************/

	/**********************/
	/***** PLAY SOUND *****/
	/**********************/

	private void playSound () {

		if (this.coinSound.isPlaying) {
			
			this.coinSound.Stop ();
			this.coinSound.Play ();

		} else {
			
			this.coinSound.Play ();

		}
			
	}
		
	/**************************************************/
	/**************************************************/

	/***************************/
	/***** CHECK COLLISION *****/
	/***************************/

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.name == "Player" && other.GetType() == typeof(CircleCollider2D)) {
			this.updateScore ();
			this.playSound ();
		}

	}
		
	/**************************************************/
	/**************************************************/

	/************************/
	/***** UPDATE SCORE *****/
	/************************/

	private void updateScore() {
		this.scoreManager.addScore (this.scoreToGive);
		this.gameObject.SetActive (false);
	}

		
}