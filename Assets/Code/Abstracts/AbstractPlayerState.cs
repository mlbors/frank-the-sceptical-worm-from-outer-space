/**
 * FTSWFOS - AbstractPlayerState - Abstract Class
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

/*********************************/
/***** ABSTRACT PLAYER STATE *****/
/*********************************/

abstract public class AbstractPlayerState : IPlayerState 
{
    /****************/
    /***** JUMP *****/
    /****************/

    /**
     * @access public
     */

    abstract public void Jump();
}
