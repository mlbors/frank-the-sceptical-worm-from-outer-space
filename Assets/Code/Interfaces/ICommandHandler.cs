/**
 * FTSWFOS - ICommandHandler - Interface
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
/***** ICOMMAND HANDLER *****/
/****************************/

public interface ICommandHandler
{
    ICommand Command
    {
        get;
        set;
    }

    void HandleInput();
    void ExecuteCommand();
}