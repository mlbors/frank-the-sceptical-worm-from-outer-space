/**
 * FTSWFOS - DeathMenu.cs
 *
 * @since       05.06.2017
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

public class DeathMenu : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public string mainMenuLevel;

	//PRIVATE
	//-------

	/**************************************************/
	/**************************************************/

	/************************/
	/***** RESTART GAME *****/
	/************************/

	public void restartGame () {

		FindObjectOfType<GameManager> ().reset ();

	}

	/**************************************************/
	/**************************************************/

	/************************/
	/***** QUIT TO MAIN *****/
	/************************/

	public void quitToMain () {
		SceneManager.LoadScene (this.mainMenuLevel);
	}

}
