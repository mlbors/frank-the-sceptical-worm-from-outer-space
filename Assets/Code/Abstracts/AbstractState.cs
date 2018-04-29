/**
 * FTSWFOS - AbstractState - Abstract Class
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

/**************************/
/***** ABSTRACT STATE *****/
/**************************/

abstract public class AbstractState : IState, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IStateSubject _stateSubject subject affected by the state
     */

    protected IStateSubject _stateSubject;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param IStateSubject stateSubject subject affected by the state
     */

    protected AbstractState(IStateSubject stateSubject)
    {
        _stateSubject = stateSubject;
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** STATE SUBJECT GETTER/SETTER *****/
    /***************************************/

    /**
     * @access public
     */

    public IStateSubject StateSubject
    {
        get { return _stateSubject; }
        set { _stateSubject = value; }
    }

    /**************************************************/
    /**************************************************/

    /************************/
    /***** ISTATE ENTER *****/
    /************************/

    /**
     * @access public
     */

    public abstract void Enter();

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** ISTATE UPDATE *****/
    /*************************/

    /**
     * @access public
     */

    public abstract void Update();
}
