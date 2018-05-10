/**
 * FTSWFOS - AbstractFactory - Abstract Class
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

/****************************/
/***** ABSTRACT FACTORY *****/
/****************************/

/**
 * @constraints object of type T where T is a class, inherits from K and can be instantiated
 */

abstract public class AbstractFactory<T> : IFactory<T>
{
    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @return T 
     */

    public abstract T Create(params object[] constructorArguments);
}
