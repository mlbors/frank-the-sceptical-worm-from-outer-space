/**
 * FTSWFOS - ICommand - Interface
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

/********************/
/***** ICOMMAND *****/
/********************/

public interface ICommand
{
    ICommandSubject CommandSubject
    {
        get;
        set;
    }

    IAction Action
    {
        get;
        set;
    }

    void Execute();
}