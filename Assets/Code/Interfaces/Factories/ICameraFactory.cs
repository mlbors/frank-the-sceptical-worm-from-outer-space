/**
 * FTSWFOS - ICameraFactory - Interface
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

/***************************/
/***** ICAMERA FACTORY *****/
/***************************/

public interface ICameraFactory<T> : IFactory<T>
{
    ICameraTarget Target
    {
        get;
        set;
    }
}