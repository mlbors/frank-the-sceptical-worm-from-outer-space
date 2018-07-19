/**
 * FTSWFOS - ITriggerCollision - Interface
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

/******************************/
/***** ITRIGGER COLLISION *****/
/******************************/

public interface ITriggerCollision
{
    void OnTriggerEnter2D(Collider2D other);
}