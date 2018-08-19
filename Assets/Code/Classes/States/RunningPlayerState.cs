﻿/**
 * FTSWFOS - RunningPlayerState - Abstract Class
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

/********************************/
/***** RUNNING PLAYER STATE *****/
/********************************/

public class RunningPlayerState : AbstractPlayerState
{

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ICommand _command command to execute
     */

    ICommand _command;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param ICommandFactory commandFactory object that create other objects, here, ICommand
     */

    public RunningPlayerState(ICommandFactory<ICommand> commandFactory) : base (commandFactory)
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
        _name = "Running";
        _type = PlayerStates.Running;
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
        (_stateSubject as IPlayer).Animator.SetFloat("Speed", 1.55f);
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
        if (_command == null)
        {
            _commandFactory.Type = CommandTypes.Run;
            _command = _commandFactory.Create();
            _command.CommandSubject = (_stateSubject as ICommandSubject);
        }

        _command.Execute();
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
