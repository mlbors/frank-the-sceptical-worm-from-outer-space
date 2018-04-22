/**
 * FTSWFOS - IGeneratorOperatorElement - Interface
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

/***************************************/
/***** IGENERATOR OPERATOR ELEMENT *****/
/***************************************/

public interface IGeneratorOperatorElement
{
    IGenerator Generator
    {
        get;
        set;
    }

    IDestroyer Destroyer
    {
        get;
        set;
    }
}