/**
 * FTSWFOS - ICommandHandler - Interface
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