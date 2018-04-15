﻿/**
 * FTSWFOS - ICollisionObject - Interface
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

/*****************************/
/***** ICOLLISION OBJECT *****/
/*****************************/

public interface ICollisionObject
{
    void OnCollisionEnter2D(Collision2D other);
}