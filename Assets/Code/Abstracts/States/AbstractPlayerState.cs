/**
 * FTSWFOS - AbstractPlayerState - Abstract Class
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
/***** ABSTRACT PLAYER STATE *****/
/*********************************/

abstract public class AbstractPlayerState : AbstractState, IPlayerState
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IStateSubject _stateSubject subject affected by the state
     * @var IStateInputHandler _stateInputHandler object to handle inputs
     * @var ICommandFactory _commandFactory object that create other objects, here, ICommand
     * @var PlayerStates _type type of state
     * @var String _name define state's name
     * @var Bool _canBeLeft does the state can be left?
     */

    protected IStateInputHandler _stateInputHandler;
    protected ICommandFactory<ICommand> _commandFactory;
    protected IPlayerStateSubject _stateSubject;
    protected PlayerStates _type;
    protected string _name;
    protected bool _canBeLeft = false;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param ICommandFactory commandFactory object that create other objects, here, ICommand
     */

    protected AbstractPlayerState(ICommandFactory<ICommand> commandFactory) : base ()
    {
        _commandFactory = commandFactory;
    }

    /**************************************************/
    /**************************************************/

    /*********************************************/
    /***** STATE INPUT HANDLER GETTER/SETTER *****/
    /*********************************************/

    /**
     * @access public
     */

    public IStateInputHandler StateInputHandler
    {
        get { return _stateInputHandler; }
        set { _stateInputHandler = value; }
    }

    /**************************************************/
    /**************************************************/

    /*****************************************/
    /***** COMMAND FACTORY GETTER/SETTER *****/
    /*****************************************/

    /**
     * @access public
     */

    public ICommandFactory<ICommand> CommandFactory
    {
        get { return _commandFactory; }
        set { _commandFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** STATE SUBJECT GETTER/SETTER *****/
    /***************************************/

    /**
     * @access public
     */

    public IPlayerStateSubject StateSubject
    {
        get { return _stateSubject; }
        set { _stateSubject = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** NAME GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** CAN BE LEFT GETTER/SETTER *****/
    /*************************************/

    /**
     * @access public
     */

    public bool CanBeLeft
    {
        get { return _canBeLeft; }
        set { _canBeLeft = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** TYPE GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public PlayerStates Type
    {
        get { return _type; }
        set { _type = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ABSTRACTSTATE ENTER *****/
    /*******************************/

    /**
     * @access public
     */

    public abstract override void Enter();

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** ABSTRACTSTATE UPDATE *****/
    /********************************/

    /**
     * @access public
     */

    public abstract override void Update();

    /**************************************************/
    /**************************************************/

    /************************/
    /***** ISTATE LEAVE *****/
    /************************/

    /**
     * @access public
     */

    public abstract override void Leave();

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** IPALYERSTATE HANDLE INPUT *****/
    /*************************************/

    /**
     * @access public
     */

    public abstract void HandleInput();
}
