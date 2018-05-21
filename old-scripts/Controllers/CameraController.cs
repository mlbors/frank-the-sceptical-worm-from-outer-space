/**
 * FTSWFOS - CameraController.cs
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

public class CameraController : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public PlayerController thePlayer;

	//PRIVATE
	//-------

	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {
		
		this.getComponents ();
		this.getPlayerLastPosition ();

	}

	/**************************************************/
	/**************************************************/
	
	/******************/
	/***** UPDATE *****/
	/******************/

	void Update () {

		this.setCameraMovement ();
		this.getPlayerLastPosition ();

	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** GET COMPONENTS *****/
	/**************************/

	private void getComponents () {
		this.thePlayer = FindObjectOfType<PlayerController> ();
	}

	/**************************************************/
	/**************************************************/

	/************************************/
	/***** GET PLAYER LAST POSITION *****/
	/************************************/

	private void getPlayerLastPosition () {
		this.lastPlayerPosition = this.thePlayer.transform.position;
	}

	/**************************************************/
	/**************************************************/

	/*******************************/
	/***** SET CAMERA MOVEMENT *****/
	/*******************************/

	private void setCameraMovement () {

		this.distanceToMove = this.thePlayer.transform.position.x - this.lastPlayerPosition.x;

		float xPosition = this.transform.position.x + this.distanceToMove;

		this.transform.position = new Vector3 (xPosition, this.transform.position.y, this.transform.position.z);

	}

}
