/**
 * FTSWFOS - AbstractCommand - Abstract Class
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

/****************************/
/***** ABSTRACT COMMAND *****/
/****************************/

abstract public class AbstractCommand : ICommand
{
    /****************************/
    /***** ICOMMAND EXECUTE *****/
    /****************************/

    /**
     * @access public
     */

    public abstract void Execute();
}
