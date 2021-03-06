﻿/**
 * FTSWFOS - IManagerFactory - Interface
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
/***** IMANAGER FACTORY *****/
/****************************/

public interface IManagerFactory<T> : IFactory<T>
{
    ManagerType Type
    {
        get;
        set;
    }
}