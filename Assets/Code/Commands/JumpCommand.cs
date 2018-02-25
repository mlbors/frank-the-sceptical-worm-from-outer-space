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

public class JumpCommand : AbstractCommand, IProduct
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
     * @access public
     * @param IState state player's state
     */

    public JumpCommand(IPlayerState state)
    {
        _state = state;
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** ICOMMAND EXECUTE *****/
    /****************************/

    /**
     * @access public
     */

    public override void Execute()
    {
        _state.Jump();
    }
}