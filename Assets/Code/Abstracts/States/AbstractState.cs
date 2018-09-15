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
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param IStateSubject stateSubject subject affected by the state
     */

    protected AbstractState()
    {

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

    /**************************************************/
    /**************************************************/

    /************************/
    /***** ISTATE LEAVE *****/
    /************************/

    /**
     * @access public
     */

    public abstract void Leave();
}