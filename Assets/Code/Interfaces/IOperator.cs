/**
 * FTSWFOS - IOperator - Interface
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

/*********************/
/***** IOEPRATOR *****/
/*********************/

public interface IOperator
{
    void Init();
    void AddElement(IOperatorElement component);
    void Operate();
}