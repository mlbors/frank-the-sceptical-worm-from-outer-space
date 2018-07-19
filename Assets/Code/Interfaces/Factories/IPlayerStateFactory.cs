/**
 * FTSWFOS - IPlayerStateFactory - Interface
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

/*********************************/
/***** IPLAYER STATE FACTORY *****/
/*********************************/

public interface IPlayerStateFactory<T> : IFactory<T>
{
    PlayerStates Type
    {
        get;
        set;
    }
}