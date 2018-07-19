/**
 * FTSWFOS - IGameManager - Interface
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
/***** IGAME MANAGER *****/
/*************************/

public interface IGameManager
{
    List<IOperator> Operators
    {
        get;
        set;
    }

    IOperatorFactory<IOperator> OperatorFactory
    {
        get;
        set;
    }

    void AddOperator(IOperator theOperator);
    void RemoveOperator(IOperator theOperator);
}