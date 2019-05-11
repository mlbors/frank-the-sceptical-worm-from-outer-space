/**
 * FTSWFOS - IMenuFactory - Interface
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

/*************************/
/***** IMENU FACTORY *****/
/*************************/

public interface IMenuFactory<T> : IFactory<T>
{
    MenuType Type
    {
        get;
        set;
    }

    List<GameObject> GameObjects
    {
        get;
        set;
    }

    GameObject Canvas
    {
        get;
        set;
    }
}