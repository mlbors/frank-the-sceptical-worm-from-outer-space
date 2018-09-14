/**
 * FTSWFOS - JumpingPlayerState - Abstract Class
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
/***** JUMPING PLAYER STATE *****/
/********************************/

public class JumpingPlayerState : AbstractPlayerState
{

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ICommand _command command to execute
     */

    protected ICommand _command;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param ICommandFactory commandFactory object that create other objects, here, ICommand
     */

    public JumpingPlayerState(ICommandFactory<ICommand> commandFactory) : base (commandFactory)
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
        _name = "Jumping";
        _type = PlayerStates.Jumping;
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
        (_stateSubject as IPlayer).Animator.SetBool("isGrounded", false);
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
            _commandFactory.Type = CommandTypes.Jump;
            _command = _commandFactory.Create();
            _command.CommandSubject = (_stateSubject as ICommandSubject);
        }

        _command.Execute();

        _stateSubject.ChangeState(PlayerStates.Running);
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
