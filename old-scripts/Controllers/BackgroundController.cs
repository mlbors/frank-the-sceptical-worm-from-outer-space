/**
 * FTSWFOS - BackgroundController.cs
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

/**********************/
/***** CONTROLLER *****/
/**********************/

public class BackgroundController : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public float smoothing;

	public Transform[] fixedBackgrounds;
	public Transform[] backgrounds;

	//PRIVATE
	//-------

	private float[] parallaxScales;

	private Vector3 lastFixedBackgroundPosition;
	private Vector3 previousCameraPosition;

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
		this.manageBackgrounds ();
	}
	
	/**************************************************/
	/**************************************************/

	/***********************/
	/***** LATE UPDATE *****/
	/***********************/

	void LateUpdate () {
		
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
		this.setPreviousCameraPosition ();
		this.setParallaxScales ();
	}

	/*****/
	/***** PREVIOUS CAMERA POSITION *****/
	/*****/

	private void setPreviousCameraPosition () {
		this.previousCameraPosition = this.transform.position;
	}

	/*****/
	/***** PARALLAX SCALES *****/
	/*****/

	private void setParallaxScales () {
		
		this.parallaxScales = new float[this.backgrounds.Length];

		for (int i = 0; i < this.parallaxScales.Length; i++) {
			this.parallaxScales [i] = this.backgrounds [i].position.z * -1;
		}

	}

	/**************************************************/
	/**************************************************/

	/******************************/
	/***** MANAGE BACKGROUNDS *****/
	/******************************/

	private void manageBackgrounds() {
		this.moveFixedBackground ();
		this.moveBackgrounds ();
		this.setPreviousCameraPosition ();
	}

	/**************************************************/
	/**************************************************/

	/*********************************/
	/***** MOVE FIXED BACKGROUND *****/
	/*********************************/

	private void moveFixedBackground() {
		
		float distanceToMoveX = this.transform.position.x;

		if (this.fixedBackgrounds.Length > 0) {
			
			for (int i = 0; i < this.fixedBackgrounds.Length; i++) {

				this.fixedBackgrounds [i].transform.position = new Vector3 (distanceToMoveX, this.fixedBackgrounds [i].transform.position.y, this.fixedBackgrounds [i].transform.position.z);

			}

		}
			
	}

	/**************************************************/
	/**************************************************/

	/****************************/
	/***** MOVE BACKGROUNDS *****/
	/****************************/

	private void moveBackgrounds() {

		if (this.backgrounds.Length > 0) {

			for (int i = 0; i < this.backgrounds.Length; i++) {

				float parallax = (this.previousCameraPosition.x - this.transform.position.x) * (this.parallaxScales [i] / this.smoothing);
				float backgroundPosX = this.backgrounds [i].position.x + parallax;
				Vector3 backgroundPos = new Vector3 (backgroundPosX, this.backgrounds[i].position.y, this.backgrounds[i].position.z);
				this.backgrounds [i].position = Vector3.Lerp (this.backgrounds [i].position, backgroundPos, this.smoothing * Time.deltaTime);

			}

		}
			
	}

}
