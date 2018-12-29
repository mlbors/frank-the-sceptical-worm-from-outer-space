/**
 * FTSWFOS - IOjectComputerFactory - Interface
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
/***** IOBJECT COMPUTER FACTORY *****/
/************************************/

public interface IObjectComputerFactory<T> : IFactory<T>
{
    ObjectComputerType Type
    {
        get;
        set;
    }
}