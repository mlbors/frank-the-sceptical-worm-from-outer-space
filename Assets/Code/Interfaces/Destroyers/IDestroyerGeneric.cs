/**
 * FTSWFOS - IDestroyerGeneric - Interface
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

/******************************/
/***** IDESTROYER GENERIC *****/
/******************************/

public interface IDestroyer<T> : IDestroyer
{
    IPool<T> Pool
    {
        get;
        set;
    }
}