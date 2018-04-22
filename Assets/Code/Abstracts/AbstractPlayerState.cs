/**
 * FTSWFOS - AbstractPlayerState - Abstract Class
 *
 * @since       09.01.2018
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
     * @var IStateInputHandler object to handle inputs
     * @var IFactory object that create other objects, here, ICommand
     */

    protected IStateInputHandler _stateInputHandler;
    protected IFactory _commandFactory;

    /**************************************************/
    /**************************************************/

    /*********************************************/
    /***** STATE INPUT HANDLER GETTER/SETTER *****/
    /*********************************************/

    /*
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

    /*
     * @access public
     */

    public IFactory CommandFactory
    {
        get { return _commandFactory; }
        set { _commandFactory = value; }
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

    /*******************************/
    /***** IPALYERSTATE UPDATE *****/
    /*******************************/

    /**
     * @access public
     */

    public abstract void HandleInput();
}
