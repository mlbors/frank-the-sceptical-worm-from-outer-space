/**
 * FTSWFOS - CoinGenerator.cs
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

/*********************/
/***** GENERATOR *****/
/*********************/

public class CoinGenerator : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public float distanceBetweenCoins;

	public ObjectPooler coinPool;

	//PRIVATE
	//-------

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {
		
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
	}

	/**************************************************/
	/**************************************************/

	/***********************/
	/***** SPAWN COINS *****/
	/***********************/

	public void spawnCoins(Vector3 startPosition) {

		for (int i = 0; i < 3; i++) {

			GameObject coin = coinPool.getPooledObject ();
			coin.transform.position = startPosition;
			coin.SetActive (true);

			switch(i) {
				case 0:
					coin.transform.position = startPosition;
					break;

				case 1:
					coin.transform.position = new Vector3 (startPosition.x - this.distanceBetweenCoins, startPosition.y, startPosition.z);
					break;

				case 2:
				coin.transform.position = new Vector3 (startPosition.x + this.distanceBetweenCoins, startPosition.y, startPosition.z);
					break;
			}
					
			coin.SetActive (true);

		}


	}
		
}
