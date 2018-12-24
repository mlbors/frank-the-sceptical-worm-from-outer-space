/**
 * FTSWFOS - IOjectComputerGeneric - Interface
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
/***** IOBJECT COMPUTER GENERIC *****/
/************************************/

public interface IObjectComputer<T> : IObjectComputer
{
    Stack<T> GeneratedObjects
    {
        get;
        set;
    }

    T CurrentObject
    {
        get;
        set;
    }
}