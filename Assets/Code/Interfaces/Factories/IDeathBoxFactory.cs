/**
 * FTSWFOS - IDeathBoxFactory - Interface
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
/***** IDEATH BOX FACTORY *****/
/******************************/

public interface IDeathBoxFactory<T> : IFactory<T>
{
    GameObject GameObject
    {
        get;
        set;
    }

    MonoBehaviour TargetObject
    {
        get;
        set;
    }
}