/**
 * FTSWFOS - MainMenu.cs
 *
 * @since       30.05.2017
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
using UnityEngine.SceneManagement;

/**************************************************/
/**************************************************/

/****************/
/***** MENU *****/
/****************/

public class MainMenu : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public string playGameLevel;

	//PRIVATE
	//-------

	/**************************************************/
	/**************************************************/

	/*********************/
	/***** PLAY GAME *****/
	/*********************/

	public void playGame() {
		SceneManager.LoadScene (this.playGameLevel);
	}

	/**************************************************/
	/**************************************************/

	/*********************/
	/***** QUIT GAME *****/
	/*********************/

	public void quitGame() {
		Application.Quit ();
	}
		
}
