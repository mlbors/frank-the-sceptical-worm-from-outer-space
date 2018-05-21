/**
 * FTSWFOS - ObjectDestroyer.cs
 *
 * @since       05.03.2017
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
/***** DESTROYER *****/
/*********************/

public class ObjectDestroyer : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public GameObject objectDestructionPoint;

	//PRIVATE
	//-------

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

	/**********************/
	/***** GET UPDATE *****/
	/**********************/

	void Update () {

		this.checkDestructionPoint ();	

	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** GET COMPONENTS *****/
	/**************************/

	private void getComponents () {
		this.objectDestructionPoint = GameObject.Find ("ObjectDestructionPoint");
	}

	/**************************************************/
	/**************************************************/

	/************************************/
	/***** CHECK DESTRUCTNION POINT *****/
	/************************************/

	private void checkDestructionPoint() {

		if ( this.doesObjectHasToBeDestroyed() ) {
			this.destroyObject ();
		}

	}

	/**************************************************/
	/**************************************************/

	/*******************************************/
	/***** DOES OBJECT HAS TO BE DESTROYED *****/
	/*******************************************/

	private bool doesObjectHasToBeDestroyed() {

		if (this.transform.position.x < this.objectDestructionPoint.transform.position.x) {
			return true;
		}

		return false;

	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** DESTROY OBJECT *****/
	/**************************/

	private void destroyObject() {
		gameObject.SetActive (false);
	}
		
}