/**
 * FTSWFOS - IPlayerState - Interface
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
/***** IPLAYER STATE *****/
/*************************/

public interface IPlayerState : IState
{
    IStateInputHandler StateInputHandler
    {
        get;
        set;
    }

    IPlayerStateSubject StateSubject
    {
        get;
        set;
    }

    PlayerStates Type
    {
        get;
        set;
    }

    string Name
    {
        get;
        set;
    }

    bool CanBeLeft
    {
        get;
        set;
    }

    void HandleInput();
}