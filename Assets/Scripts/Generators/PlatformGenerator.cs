﻿/**
 * FTSWFOS - PlateformGenerator.cs
 *
 * @since       13.01.2017
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

/*********************/
/***** GENERATOR *****/
/*********************/

public class PlatformGenerator : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public GameObject thePlatform;

	public Transform generationPoint;
	public Transform maxHeightPoint;

	public float platformDistanceBetweenMin;
	public float plateformDistanceBetweenMax;
	public float maxHeightChange;

	public ObjectPooler[] theObjectPools;

	//PRIVATE
	//-------

	private float platformWidth;
	private float distanceBetween;
	private float minHeight;
	private float maxHeight;
	private float heightChange;

	private int platformSelector;

	private float[] platformWidths;

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {
		this.getComponents ();
	}

	/**************************************************/
	/**************************************************/

	/******************/
	/***** UPDATE *****/
	/******************/

	void Update () {
		this.plateformsGeneration ();
	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** GET COMPONENTS *****/
	/**************************/

	private void getComponents () {

		this.objectPooling ();
		this.setHeights ();

	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** OBJECT POOLING *****/
	/**************************/

	private void objectPooling () {

		this.platformWidths = new float[this.theObjectPools.Length];

		for (int i = 0; i < this.theObjectPools.Length; i++) {
			this.platformWidths[i] = this.theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

	}

	/**************************************************/
	/**************************************************/

	/*******************/
	/***** SETTERS *****/
	/*******************/

	/*****/
	/***** HEIGHTS *****/
	/*****/

	private void setHeights () {
		this.minHeight = this.transform.position.y;
		this.maxHeight = this.maxHeightPoint.position.y;
	}

	/*****/
	/***** PLATFORM SELECTOR *****/
	/*****/

	private void setPlatformSelector  () {
		this.platformSelector = Random.Range (0, this.theObjectPools.Length);
	}

	/*****/
	/***** DISTANCE BETWEEN *****/
	/*****/

	private void setDistanceBetween () {
		this.distanceBetween = Random.Range (this.platformDistanceBetweenMin, this.plateformDistanceBetweenMax);
	}

	/*****/
	/***** HEIGHT CHANGE *****/
	/*****/

	private void setHeightChange () {
		
		this.heightChange = this.transform.position.y + Random.Range (this.maxHeightChange, -this.maxHeightChange);

		if (this.heightChange > this.maxHeight) {
			this.heightChange = this.maxHeight;
		} else if (this.heightChange < this.minHeight) {
			this.heightChange = this.minHeight;
		}

	}

	/*****/
	/***** SET POSITION *****/
	/*****/

	private void setPosition( float xPosition ) {
		this.transform.position = new Vector3 (xPosition, this.heightChange, this.transform.position.z);
	}

	/**************************************************/
	/**************************************************/

	/*********************************/
	/***** PLATEFORMS GENERATION *****/
	/*********************************/

	private void plateformsGeneration () {
		this.plateformFeed ();
	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** PALTEFORM FEED *****/
	/**************************/

	private void plateformFeed() {

		if (this.isGenerationPointAhead ()) {
			this.generateNewPlatform ();
		}

	}

	/**************************************************/
	/**************************************************/

	/**************************************/
	/***** IS GENERATION POINT BEHIND *****/
	/**************************************/

	private bool isGenerationPointAhead () {

		if (this.transform.position.x < this.generationPoint.position.x) {
			return true;
		}

		return false;

	}

	/**************************************************/
	/**************************************************/

	/***********************************/
	/***** GENERATE A NEW PLATFORM *****/
	/***********************************/

	private void generateNewPlatform () {

		this.setDistanceBetween ();
		this.setPlatformSelector ();
		this.setHeightChange ();

		float xPosition = this.computeXPosition ();

		this.setPosition (xPosition);

		this.poolThePlatform ();

		this.movePlatformGenerator ();

	}

	/**************************************************/
	/**************************************************/

	/******************************/
	/***** COMPUTE X POSITION *****/
	/******************************/

	private float computeXPosition () {
		float intermediatePosition = this.transform.position.x + (this.platformWidths [this.platformSelector] / 2);
		float xPosition = intermediatePosition + this.distanceBetween;
		return xPosition;
	}

	/**************************************************/
	/**************************************************/

	/*****************************/
	/***** POOL THE PLATFORM *****/
	/*****************************/

	private void poolThePlatform () {
		
		GameObject newPlatform = this.theObjectPools[this.platformSelector].getPooledObject ();
		newPlatform.transform.position = this.transform.position;
		newPlatform.transform.rotation = this.transform.rotation;
		newPlatform.SetActive (true);

	}

	/**************************************************/
	/**************************************************/

	/***********************************/
	/***** MOVE PLATFORM GENERATOR *****/
	/***********************************/

	private void movePlatformGenerator () {
		this.transform.position = new Vector3 (this.transform.position.x + (this.platformWidths [this.platformSelector] / 2), this.transform.position.y, this.transform.position.z);
	}

}
