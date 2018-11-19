/**
 * FTSWFOS - IPlatformPool - Interface
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

/**************************/
/***** IPLATFORM POOL *****/
/**************************/

public interface IPlatformPool
{
    PlatformType NeedType
    {
        get;
        set;
    }
}