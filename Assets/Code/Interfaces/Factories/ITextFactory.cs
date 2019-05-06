/**
 * FTSWFOS - ITextFactory - Interface
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
using UnityEngine.UI;

/**************************************************/
/**************************************************/

/*************************/
/***** ITEXT FACTORY *****/
/*************************/

public interface ITextFactory<T> : IFactory<T>
{
    TextType Type
    {
        get;
        set;
    }

    List<GameObject> GameObjects
    {
        get;
        set;
    }
}