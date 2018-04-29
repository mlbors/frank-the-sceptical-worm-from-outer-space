/**
 * FTSWFOS - IOperator - Interface
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

/*********************/
/***** IOEPRATOR *****/
/*********************/

public interface IOperator
{
    void Init();
    void AddElement(IOperatorElement component);
    void RemoveElement(IOperatorElement component);
    void Operate();
}