﻿/**
 * FTSWFOS - IEnvironmentObject - Interface
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

/*******************************/
/***** IENVIRONMENT OBJECT *****/
/*******************************/

public interface IEnvironmentObject
{
    EnvironmentObjectType Type
    {
        get;
        set;
    }

    MonoBehaviour FollowedObject
    {
        get;
        set;
    }

    float X
    {
        get;
        set;
    }

    float Y
    {
        get;
        set;
    }

    float Z
    {
        get;
        set;
    }
}