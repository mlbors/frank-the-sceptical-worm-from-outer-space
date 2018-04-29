﻿/**
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
     * @var IStateInputHandler _stateInputHandler object to handle inputs
     * @var IFactory _commandFactory object that create other objects, here, ICommand
     */

    protected IStateInputHandler _stateInputHandler;
    protected IFactory _commandFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param IStateSubject stateSubject subject affected by the state
     * @param IStateInputHandler stateInputHandler object to handle inputs
     * @param IFactory commandFactory object that create other objects, here, ICommand
     */

    protected AbstractPlayerState(IStateSubject stateSubject, IStateInputHandler stateInputHandler, IFactory commandFactory) : base (stateSubject)
    {
        _stateInputHandler = stateInputHandler;
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

    /*************************************/
    /***** IPALYERSTATE HANDLE INPUT *****/
    /*************************************/

    /**
     * @access public
     */

    public abstract void HandleInput();
}