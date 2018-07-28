/**
 * FTSWFOS - JumpCommand - Concrete Class
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

/************************/
/***** JUMP COMMAND *****/
/************************/

public class JumpCommand : AbstractCommand
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IAction action action to perform
     */

    public JumpCommand(IAction action) : base(action)
    {

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

    }
}