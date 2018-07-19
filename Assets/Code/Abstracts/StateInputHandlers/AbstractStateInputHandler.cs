/**
 * FTSWFOS - AbstractStateInputHandler - Abstract Class
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

/****************************************/
/***** ABSTRACT STATE INPUT HANDLER *****/
/****************************************/

abstract public class AbstractStateInputHandler : IProduct, IStateInputHandler
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ICommandHandler _inputHandler object that handles inputs
     */

    protected ICommandHandler _inputHandler;

    /**************************************************/
    /**************************************************/

    /***********************************************/
    /***** INPUT HANDLER SUBJECT GETTER/SETTER *****/
    /***********************************************/

    /**
     * @access public
     */

    public ICommandHandler InputHandler
    {
        get { return _inputHandler; }
        set { _inputHandler = value; }
    }

    /**************************************************/
    /**************************************************/

    /*********************************************/
    /***** ISTATE INPUT HANDLER HANDLE INPUT *****/
    /*********************************************/

    /**
     * @access public
     */

    public abstract void HandleInput();
}
