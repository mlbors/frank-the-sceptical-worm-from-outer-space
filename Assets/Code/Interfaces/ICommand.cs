﻿/**
 * FTSWFOS - ICommand - Interface
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

/********************/
/***** ICOMMAND *****/
/********************/

public interface ICommand
{
    IPlayerState State
    {
        get;
        set;
    }

    void Execute();
}