/**
 * FTSWFOS - AbstractCommandHandler - Abstract Class
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

/************************************/
/***** ABSTRACT COMMAND HANDLER *****/
/************************************/

abstract public class AbstractInputHandler : ICommandHandler, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ICommand _command sended command
     */

    protected ICommand _command;

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** COMMAND GETTER/SETTER *****/
    /*********************************/

    /**
     * @access public
     */

    public ICommand Command
    {
        get { return _command; }
        set { _command = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** EXECUTE COMMAND *****/
    /***************************/

    /**
     * @access public
     */

    public void ExecuteCommand()
    {
        _command.Execute();
    }

    /**************************************************/
    /**************************************************/

    /************************/
    /***** HANDLE INPUT *****/
    /************************/

    /**
     * @access public
     */

    public abstract void HandleInput();
}
