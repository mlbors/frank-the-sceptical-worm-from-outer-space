﻿/**
 * FTSWFOS - IGeneratorFactory - Interface
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
/***** IGENERATOR FACTORY *****/
/******************************/

public interface IGeneratorFactory<T> : IFactory<T>
{
    GeneratorType Type
    {
        get;
        set;
    }
}