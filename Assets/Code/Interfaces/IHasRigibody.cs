/**
 * FTSWFOS - IHasRigidbody - Interface
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

/**************************/
/***** IHAS RIGIDBODY *****/
/**************************/

public interface IHasRigidbody
{
    Rigidbody2D Rigidbody
    {
        get;
        set;
    }
}