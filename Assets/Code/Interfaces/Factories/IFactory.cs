﻿/**
 * FTSWFOS - IFactory - Interface
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

/********************/
/***** IFACTORY *****/
/********************/

public interface IFactory<T>
{
    T Create(params object[] constructorArguments);
}