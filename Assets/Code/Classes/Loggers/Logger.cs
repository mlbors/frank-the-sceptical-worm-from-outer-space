/**
 * FTSWFOS - Logger - Static Class
 *
 * @since       2018.01.09
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/**************************************************/
/**************************************************/

/******************/
/***** LOGGER *****/
/******************/

public static class Logger
{   
    /***********************/
    /***** LOG MESSAGE *****/
    /***********************/

    /**
     * @access public
     * @param string message string to log
     */

    public static void LogMessage(string message)
    {
        try
        {
            Debug.Log(message);
        }
        catch (Exception e)
        {
            LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /***********************/
    /***** LOG MESSAGE *****/
    /***********************/

    /**
     * @access public
     * @param object data object to log
     */

    public static void LogMessage(object data)
    {
        try
        {
            Debug.Log(data);
        }
        catch (Exception e)
        {
            LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** LOG EXCEPTION *****/
    /*************************/

    /**
     * @access public
     * @param exception exception exception to log
     */

    public static void LogException(Exception exception)
    {
        Debug.Log("***** EXCEPTION *****");
        Debug.Log($"Exception of type {exception.GetType()} thrown: {exception.Source}");
        Debug.Log(exception.Message);
        Debug.Log(exception.StackTrace);
        Debug.Log("***** END EXCEPTION *****");
    }
}