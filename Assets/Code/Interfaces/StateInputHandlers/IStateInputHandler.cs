/**
 * FTSWFOS - IStatInputHandler - Interface
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