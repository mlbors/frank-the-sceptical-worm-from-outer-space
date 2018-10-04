/**
 * FTSWFOS - IGeneratorComposite - Interface
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

/********************************/
/***** IGENERATOR COMPOSITE *****/
/********************************/

public interface IGeneratorComposite<T> : IGenerator<T>
{
    List<IOperatorElement> OperatorElements
    {
        get;
        set;
    }

    void AddOperatorElement(IOperatorElement operatorElement);
    void RemoveOperatorElement(IOperatorElement operatorElement);
    void ExecuteOperatorElements();
}