/**
 * FTSWFOS - ICollectableFactory - Interface
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

/********************************/
/***** ICOLLECTABLE FACTORY *****/
/********************************/

public interface ICollectableFactory<T> : IFactory<T>
{
    CollectableType Type
    {
        get;
        set;
    }

    List<GameObject> GameObjects
    {
        get;
        set;
    }

    IOperatorElement ScoreOperator
    {
        get;
        set;
    }
}