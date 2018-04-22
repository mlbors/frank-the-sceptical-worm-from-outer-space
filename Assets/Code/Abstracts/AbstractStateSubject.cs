/**
 * FTSWFOS - AbstractStateSubject - Abstract Class
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

/**********************************/
/***** ABSTRACT STATE SUBJECT *****/
/**********************************/

abstract public class AbstractStateSubject : IStateSubject
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IState _state object's state
     */

    protected IState _state;

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** STATE GETTER/SETTER *****/
    /*******************************/

    /*
     * @access public
     */

    public IState State
    {
        get { return _state; }
        set { _state = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** ISTATE SUBJECT UPDATE STATE *****/
    /***************************************/

    /**
     * @access public
     */

    public abstract void UpdateState();
}
