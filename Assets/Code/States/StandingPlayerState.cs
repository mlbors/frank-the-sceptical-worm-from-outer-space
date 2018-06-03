/**
 * FTSWFOS - StandingPlayerState - Abstract Class
 *
 * @since       2018.01.09
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

/*********************************/
/***** STANDING PLAYER STATE *****/
/*********************************/

public class StandingPlayerState : AbstractPlayerState
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param ICommandFactory commandFactory object that create other objects, here, ICommand
     */

    public StandingPlayerState(ICommandFactory<ICommand> commandFactory) : base (commandFactory)
    {
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ABSTRACTSTATE ENTER *****/
    /*******************************/

    /**
     * @access public
     */

    public override void Enter()
    {

    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** ABSTRACTSTATE UPDATE *****/
    /********************************/

    /**
     * @access public
     */

    public override void Update()
    {

    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** IPALYERSTATE HANDLE INPUT *****/
    /*************************************/

    /**
     * @access public
     */

    public override void HandleInput()
    {

    }
}
