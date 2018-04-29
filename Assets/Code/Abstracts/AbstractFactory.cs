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

abstract public class AbstractFactory
{
    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return T 
     */

    public abstract T Create<T, K>(params object[] constructorArguments) where T : class, K, new();

    /*
    public static T Create<T>(params object[] constructorArguments) where T : class, K
    {
        return (T)Activator.CreateInstance(typeof(T), constructorArguments);
    }

    HandlerFactory.CreateInstance<Handler3>(param1, param2);
    */
}
