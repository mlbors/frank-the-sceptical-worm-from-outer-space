/**
 * FTSWFOS - PauseMenu.cs
 *
 * @since       11.06.2017
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

public class PauseMenu : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public string mainMenuLevel;
	public GameObject pauseMenu;

	//PRIVATE
	//-------

	/**************************************************/
	/**************************************************/

	/**********************/
	/***** PAUSE GAME *****/
	/**********************/

	public void pauseGame () {
		
		Time.timeScale = 0f;
		this.pauseMenu.SetActive (true);

	}

	/**************************************************/
	/**************************************************/

	/***********************/
	/***** RESUME GAME *****/
	/***********************/

	public void resumeGame () {
		
		Time.timeScale = 1f;
		this.pauseMenu.SetActive (false);

	}

	/**************************************************/
	/**************************************************/

	/************************/
	/***** RESTART GAME *****/
	/************************/

	public void restartGame () {

		Time.timeScale = 1f;
		this.pauseMenu.SetActive (false);
		FindObjectOfType<GameManager> ().reset ();

	}

	/**************************************************/
	/**************************************************/

	/************************/
	/***** QUIT TO MAIN *****/
	/************************/

	public void quitToMain () {

		Time.timeScale = 1f;
		SceneManager.LoadScene (this.mainMenuLevel);

	}
}
