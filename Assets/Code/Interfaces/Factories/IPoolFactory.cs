/**
 * FTSWFOS - IPoolFactory - Interface
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

/*************************/
/***** IPOOL FACTORY *****/
/*************************/

public interface IPoolFactory<T> : IFactory<T>
{
    PoolType Type
    {
        get;
        set;
    }
}