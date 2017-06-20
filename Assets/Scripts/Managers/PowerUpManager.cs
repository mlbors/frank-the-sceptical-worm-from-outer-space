﻿/**
 * FTSWFOS - PowerUpManager.cs
 *
 * @since       20.06.2017
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

/*******************/
/***** MANAGER *****/
/*******************/

public class PowerUpManager : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	//PRIVATE
	//-------

	private bool doublePoints;
	private bool safeMode;
	private bool active;

	private float durationCounter;
	private float normalPointsPerSecond;
	private float spikeRate;

	private ScoreManager scoreManager;
	private PlatformGenerator platformGenerator;

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
		this.usePowerUp ();
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
		this.setPlatformGenerator ();

	}

	/*****/
	/***** SCORE MANAGER *****/
	/*****/

	private void setScoreManager () {
		this.scoreManager = FindObjectOfType<ScoreManager> ();
	}

	/*****/
	/***** PLATFORM GENERATOR *****/
	/*****/

	private void setPlatformGenerator () {
		this.platformGenerator = FindObjectOfType<PlatformGenerator> ();
	}

	/*****/
	/***** DOUBLE POINTS *****/
	/*****/

	private void setDoublePoints (bool value) {
		this.doublePoints = value;
	}

	/*****/
	/***** SAFE MODE *****/
	/*****/

	private void setSafeMode (bool value) {
		this.safeMode = value;
	}

	/*****/
	/***** DURATION COUNTER *****/
	/*****/

	private void setDurationCounter (float value) {
		this.durationCounter = value;
	}

	/*****/
	/***** ACTIVE *****/
	/*****/

	private void setActive (bool value) {
		this.active = value;
	}

	/*****/
	/***** NORMAL POINTS PER SECOND *****/
	/*****/

	private void setNormalPointsPerSecond () {
		this.normalPointsPerSecond = this.scoreManager.pointsPerSecond;
	}

	/*****/
	/***** SPIKE RATE *****/
	/*****/

	private void setSpikeRate () {
		this.spikeRate = this.platformGenerator.randomSpikeTreshold;
	}

	/*****/
	/***** POINTS PER SECOND *****/
	/*****/

	private void setPointsPerSecond (float value) {
		this.scoreManager.pointsPerSecond = value;
	}
		
	/*****/
	/***** SPIKE TRESHOLD *****/
	/*****/

	private void setSpikeThreshold (float value) {
		this.platformGenerator.randomCoinThreshold = value;
	}

	/**************************************************/
	/**************************************************/

	/*************************/
	/***** USER POWER UP *****/
	/*************************/

	private void usePowerUp () {

		if (this.active) {

			this.durationCounter -= Time.deltaTime;

			if (this.doublePoints) {
				this.setPointsPerSecond (this.normalPointsPerSecond * 2f);
			}

			if (this.safeMode) {
				this.setSpikeThreshold (0);
			}

			if (this.durationCounter <= 0) {
				this.setActive (false);
				this.setPointsPerSecond (this.normalPointsPerSecond);
				this.setSpikeThreshold (this.spikeRate);
			}

		}

	}

	/**************************************************/
	/**************************************************/

	/*****************************/
	/***** ACTIVATE POWER UP *****/
	/*****************************/

	public void activatePowerUp (bool doublePoints, bool safeMode, float duration) {

		this.setDoublePoints (doublePoints);
		this.setSafeMode (safeMode);
		this.setDurationCounter (duration);
		this.setNormalPointsPerSecond ();
		this.setSpikeRate ();
		this.setActive (true);

	}

}
