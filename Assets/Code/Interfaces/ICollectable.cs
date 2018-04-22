/**
 * FTSWFOS - ICollectable - Interface
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

/************************/
/***** ICOLLECTABLE *****/
/************************/

public interface ICollectable
{
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