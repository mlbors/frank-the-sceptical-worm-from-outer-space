﻿/**
 * FTSWFOS - IPlayerFactory - Interface
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

/***************************/
/***** IPLAYER FACTORY *****/
/***************************/

public interface IPlayerFactory<T> : IFactory<T>
{
    IPlayerStateFactory<IPlayerState> StateFactory
    {
        get;
        set;
    }
}