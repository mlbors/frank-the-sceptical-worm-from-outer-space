/**
 * FTSWFOS - ScoreManager.cs
 *
 * @since       16.05.2017
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
using UnityEngine.UI;

/**************************************************/
/**************************************************/

/*******************/
/***** MANAGER *****/
/*******************/

public class ScoreManager : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;
	public float pointsPerSecond;

	public bool scoreIncreasing;

	//PRIVATE
	//-------

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {
		this.checkIfHighScoreExists ();
	}

	/**************************************************/
	/**************************************************/

	/******************/
	/***** UPDATE *****/
	/******************/

	void Update () {

		this.computeScore ();
		this.setScoreText ();
		this.setHighScoreText ();

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

	}
		
	/*****/
	/***** SCORE TEXT *****/
	/*****/

	private void setScoreText() {
		this.scoreText.text = "Score: " + Mathf.Round (this.scoreCount);
	}

	/*****/
	/***** HIGH SCORE TEXT *****/
	/*****/

	private void setHighScoreText() {
		this.highScoreText.text = "High Score: " + Mathf.Round (this.highScoreCount);
	}

	/**************************************************/
	/**************************************************/

	/**************************************/
	/***** CHECK IF HIGH SCORE EXISTS *****/
	/**************************************/

	private void checkIfHighScoreExists() {

		if (PlayerPrefs.HasKey("HighScore")) {
			this.highScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}

	}

	/**************************************************/
	/**************************************************/

	/*************************/
	/***** COMPUTE SCORE *****/
	/*************************/

	private void computeScore() {

		if (this.scoreIncreasing) {
			this.scoreCount += this.pointsPerSecond * Time.deltaTime;
			this.scoreAgainstHighScore ();
		}
			
	}

	/**************************************************/
	/**************************************************/

	/********************************************/
	/***** COMPARE SCORE AGAINST HIGH SCORE *****/
	/********************************************/

	private void scoreAgainstHighScore() {

		if (this.scoreCount > this.highScoreCount) {
			this.highScoreCount = this.scoreCount;
			this.saveHighScore ();
		}

	}

	/**************************************************/
	/**************************************************/

	/***************************/
	/***** SAVE HIGH SCORE *****/
	/***************************/

	private void saveHighScore() {
		PlayerPrefs.SetFloat ("HighScore", this.highScoreCount);
	}

	/**************************************************/
	/**************************************************/

	/*********************/
	/***** ADD SCORE *****/
	/*********************/

	public void addScore(int pointsToAdd) {
		this.scoreCount += pointsToAdd;
	}

}
