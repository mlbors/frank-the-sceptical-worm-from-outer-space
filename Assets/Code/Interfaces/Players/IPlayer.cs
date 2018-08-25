/**
 * FTSWFOS - IPlayer - Interface
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

/*******************/
/***** IPLAYER *****/
/*******************/

public interface IPlayer
{
    Rigidbody2D Rigidbody
    {
        get;
        set;
    }

    Animator Animator
    {
        get;
        set;
    }

    IPlayerState State
    {
        get;
        set;
    }

    IPlayerStateFactory<IPlayerState> StateFactory
    {
        get;
        set;
    }

    float MoveSpeed
    {
        get;
        set;
    }

    float SpeedMultiplier
    {
        get;
        set;
    }

    float SpeedMilestoneCount
    {
        get;
        set;
    }

    float SpeedIncreaseMilestone
    {
        get;
        set;
    }

    void HandleInput();
}