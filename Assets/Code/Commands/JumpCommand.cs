/**
 * FTSWFOS - JumpCommand - Concrete Classe
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

/************************/
/***** JUMP COMMAND *****/
/************************/

public class JumpCommand : ICommand
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IPlayerState _state player's state
     */

    private IPlayerState _state;

    /**************************************************/
    /**************************************************/

    /**
     * @param IState state player's state
     */

    public JumpCommand(IPlayerState state)
    {
        _state = state;
    }

    /****************************/
    /***** ICOMMAND EXECUTE *****/
    /****************************/

    public void Execute()
    {
        _state.Jump();
    }
}