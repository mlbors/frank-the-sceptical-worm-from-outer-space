/**
 * FTSWFOS - IDeathBoxOperatorElement - Interface
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

/***************************************/
/***** IDEATH BOX OPERATOR ELEMENT *****/
/***************************************/

public interface IDeathBoxOperatorElement : IOperatorElement, IObserver, IObservable
{
    IDeathBox DeathBox
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