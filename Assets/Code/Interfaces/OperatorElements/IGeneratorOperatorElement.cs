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

public interface IGeneratorOperatorElement
{
    Transform GenerationPoint
    {
        get;
        set;
    }

    Transform DestructionPoint
    {
        get;
        set;
    }

    void CallGenerator();
    void CallDestroyer();
}