/**
 * FTSWFOS - IFactory - Interface
 *
 * @since       09.01.2018
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

public interface IFactory
{
    T Create<T, K>(params object[] constructorArguments) where T : class, K, new();
}