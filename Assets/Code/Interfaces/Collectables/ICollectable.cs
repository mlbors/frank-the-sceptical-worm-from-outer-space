/**
 * FTSWFOS - ICollectable - Interface
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
/***** ICOLLECTABLE *****/
/************************/

public interface ICollectable
{
    CollectableType Type
    {
        get;
        set;
    }

    float X
    {
        get;
        set;
    }

    float Y
    {
        get;
        set;
    }

    void Perform();
}