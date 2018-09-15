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
        _SetValues();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    /**
     * @access protected
     */

    protected void _SetValues()
    {
        _name = "Standing";
        _type = PlayerStates.Standing;
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
        (_stateSubject as IPlayer).Animator.SetFloat("Speed", 0);
        (_stateSubject as IPlayer).Animator.SetBool("isGrounded", true);
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

    /************************/
    /***** ISTATE LEAVE *****/
    /************************/

    /**
     * @access public
     */

    public override void Leave()
    {
        CanBeLeft = false;
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
