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
     * @param IStateSubject stateSubject subject affected by the state
     * @param IStateInputHandler stateInputHandler object to handle inputs
     * @param IFactory commandFactory object that create other objects, here, ICommand
     */

    public StandingPlayerState(IStateSubject stateSubject, IStateInputHandler stateInputHandler, IFactory commandFactory) : base (stateSubject, stateInputHandler, commandFactory)
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
