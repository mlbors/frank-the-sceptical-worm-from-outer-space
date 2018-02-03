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

    /*
     * @var Istate _state player's state
     */

    private IState _state;

    /**************************************************/
    /**************************************************/

    public JumpCommand(IState state)
    {
        _state = state;
    }

    /****************************/
    /***** ICOMMAND EXECUTE *****/
    /****************************/

    public void Execute()
    {
        _state.jump();
    }
}