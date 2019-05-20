/**
 * FTSWFOS - DeathMenu - Concrete Class
 *
 * @since       2018.01.09
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Zenject;

/**************************************************/
/**************************************************/

/**********************/
/***** DEATH MENU *****/
/**********************/

public class DeathMenu : AbstractMenu
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Button _restartButton button used to restart game 
     * @var Button _quitButton button used to quit game     
     */

    protected Button _restartButton;
    protected Button _quitButton;
}