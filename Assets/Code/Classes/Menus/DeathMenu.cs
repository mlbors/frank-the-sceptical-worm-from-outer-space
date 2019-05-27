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

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    [Inject]
    public override void Construct()
    {
        _SetValues();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        _SetButtons();
        _SetActions();
    }

    /**************************************************/
    /**************************************************/

    /***********************/
    /***** SET BUTTONS *****/
    /***********************/

    protected void _SetButtons()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        _restartButton = buttons[0];
        _quitButton = buttons[1];
    }

    /**************************************************/
    /**************************************************/

    /***********************/
    /***** SET ACTIONS *****/
    /***********************/

    protected void _SetActions()
    {
        _SetRestartAction();
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** SET RESTART ACTION *****/
    /******************************/

    protected void _SetRestartAction()
    {
        _restartButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Notify(ObservableEventType.RestartButtonClicked, null);
        });
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** SET QUIT ACTION *****/
    /***************************/

    protected void _SetQuitAction()
    {
        _quitButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Logger.LogMessage("Quit button clicked");
        });
    }

}