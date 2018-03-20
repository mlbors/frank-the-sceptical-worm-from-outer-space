/**
 * FTSWFOS - AbstractInputHandler - Abstract Class
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

/*************************/
/***** INPUT HANDLER *****/
/*************************/

abstract public class AbstractInputHandler : IInputHandler
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

    /*
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
     * @param ICommand Command command to handle
     */

    public void HandleInput(ICommand Command)
    {
        _command = Command;
        ExecuteCommand();
    }
}
