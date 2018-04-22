/**
 * FTSWFOS - IStatInputHandler - Interface
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

/********************************/
/***** ISTATE INPUT HANDLER *****/
/********************************/

public interface IStateInputHandler
{
    ICommandHandler InputHandler
    {
        get;
        set;
    }

    void HandleInput();
}