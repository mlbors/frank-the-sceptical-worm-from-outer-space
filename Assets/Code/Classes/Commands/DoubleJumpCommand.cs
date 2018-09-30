/**
 * FTSWFOS - DoubleJumpCommand - Concrete Class
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

public class DoubleJumpCommand : AbstractCommand
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IActionFactory actionFactory factory of objects, here IAction
     */

    public DoubleJumpCommand(IActionFactory<IAction> actionFactory) : base (actionFactory)
    {
        _actionFactory.Type = ActionType.DoubleJump;
        Action = _actionFactory.Create();
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
        _action.Perform(_commandSubject);
    }
}