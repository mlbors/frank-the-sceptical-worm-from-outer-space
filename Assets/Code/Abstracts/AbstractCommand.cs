/**
 * FTSWFOS - AbstractCommand - Abstract Class
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

/****************************/
/***** ABSTRACT COMMAND *****/
/****************************/

abstract public class AbstractCommand : ICommand, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ICommandSubject _commandSubject subject on which to perform command
     * @var IAction _action action to perform
     */

    protected ICommandSubject _commandSubject;
    protected IAction _action;

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** SUBJECT GETTER/SETTER *****/
    /*********************************/

    /*
     * @access public
     */

    public ICommandSubject CommandSubject
    {
        get { return _commandSubject; }
        set { _commandSubject = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** ACTION GETTER/SETTER *****/
    /********************************/

    /*
     * @access public
     */

    public IAction Action
    {
        get { return _action; }
        set { _action = value; }
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** ICOMMAND EXECUTE *****/
    /****************************/

    /**
     * @access public
     */

    public abstract void Execute();
}
