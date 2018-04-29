/**
 * FTSWFOS - IGeneratorOperatorElement - Interface
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
/***** IGENERATOR OPERATOR ELEMENT *****/
/***************************************/

public interface IGeneratorOperatorElement<T>
{
    IGenerator<T> Generator
    {
        get;
        set;
    }

    IDestroyer<T> Destroyer
    {
        get;
        set;
    }
}