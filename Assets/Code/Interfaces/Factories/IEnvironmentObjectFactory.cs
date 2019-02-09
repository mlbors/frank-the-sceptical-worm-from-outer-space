/**
 * FTSWFOS - IEnvironmentObjectFactory - Interface
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

/***************************************/
/***** IENVIRONMENT OBJECT FACTORY *****/
/***************************************/

public interface IEnvironmentObjectFactory<T> : IFactory<T>
{
    EnvironmentObjectType Type
    {
        get;
        set;
    }
}