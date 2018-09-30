/**
 * FTSWFOS - IOperatorElementFactory - Interface
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
/***** IOPERATOR ELEMENT FACTORY *****/
/*************************************/

public interface IOperatorElementFactory<T> : IFactory<T>
{
    OperatorElementType Type
    {
        get;
        set;
    }
}