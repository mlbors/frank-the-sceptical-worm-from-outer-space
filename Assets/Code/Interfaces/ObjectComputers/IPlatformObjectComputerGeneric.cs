/**
 * FTSWFOS - IPlatformOjectComputerGeneric - Interface
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

/*************************************/
/***** IPLATFORM OBJECT COMPUTER *****/
/*************************************/

public interface IPlatformObjectComputer<T> : IPlatformObjectComputer, IObjectComputer<T>
{
    PlatformType PlatformType
    {
        get;
        set;
    }
}