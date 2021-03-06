﻿/**
 * FTSWFOS - IFoeFactory - Interface
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

/************************/
/***** IFOE FACTORY *****/
/************************/

public interface IFoeFactory<T> : IFactory<T>
{
    FoeType Type
    {
        get;
        set;
    }

    List<GameObject> GameObjects
    {
        get;
        set;
    }

    IOperator GameOperator
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