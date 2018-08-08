/**
 * FTSWFOS - RunCommand - Concrete Class
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

/***********************/
/***** RUN COMMAND *****/
/***********************/

public class RunCommand : AbstractCommand
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IActionFactory actionFactory factory of objects, here IAction
     */

    public RunCommand(IActionFactory<IAction> actionFactory) : base(actionFactory)
    {
        _actionFactory.Type = ActionTypes.Run;
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
        _action.Perform<ICommandSubject>(_commandSubject);
    }
}