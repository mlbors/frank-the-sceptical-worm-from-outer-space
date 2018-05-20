/**
 * FTSWFOS - AbstractManager - Abstract Class
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

/**************************************************/
/**************************************************/

/****************************/
/***** ABSTRACT MANAGER *****/
/****************************/

abstract public class AbstractManager : IManager, IProduct
{
    /*************************/
    /***** IMANAGER INIT *****/
    /*************************/

    /**
     * @access public
     */

    public abstract void Init();
}
