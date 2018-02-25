/**
 * FTSWFOS - AbstractFactory - Abstract Class
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
/***** ABSTRACT FACTORY *****/
/****************************/

abstract public class AbstractFactory<T, K> : IFactory<T, K> where T : class, K, new()
{
    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @return T 
     */

    public abstract T Create();
}
