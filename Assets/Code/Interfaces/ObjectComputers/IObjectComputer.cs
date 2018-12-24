/**
 * FTSWFOS - IOjectComputer - Interface
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
/***** IOBJECT COMPUTER *****/
/****************************/

public interface IObjectComputer
{
    PlatformType PlatformType
    {
        get;
        set;
    }

    Vector3 ExecuteComputation();
}