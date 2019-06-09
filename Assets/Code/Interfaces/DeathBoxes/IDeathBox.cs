/**
 * FTSWFOS - IDeathBox - Interface
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

/**********************/
/***** IDEATH BOX *****/
/**********************/

public interface IDeathBox
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

    float Width
    {
        get;
        set;
    }

    float Height
    {
        get;
        set;
    }

    void Operate();
}