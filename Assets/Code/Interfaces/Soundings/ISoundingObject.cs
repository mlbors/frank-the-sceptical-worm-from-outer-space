﻿/**
 * FTSWFOS - ISoundingObject - Interface
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

/****************************/
/***** ISOUNDING OBJECT *****/
/****************************/

public interface ISoundingObject
{
    AudioSource Sound
    {
        get;
        set;
    }

    void PlaySound();
}