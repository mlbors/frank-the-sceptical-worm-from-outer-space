/**
 * FTSWFOS - EnvironmentObjectGenerator - Concrete Class
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

/**************************************************/
/**************************************************/

/****************************************/
/***** ENVIRONMENT OBJECT GENERATOR *****/
/****************************************/

public class EnvironmentObjectGenerator : AbstractGenerator<IEnvironmentObject>, IEnvironmentObjectGenerator
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    public EnvironmentObjectGenerator() : base()
    {
    }

    /**************************************************/
    /**************************************************/

    /****************/
    /***** INIT *****/
    /****************/

    /**
     * @access public
     */

    public override void Init()
    {
        _pool.Init();
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public override void Generate()
    {
        try
        {

        }
        catch (Exception e)
        {
            Debug.Log($"Exception thrown: {e.Message}");
            Debug.Log($"Exception thrown: {e.StackTrace}");
        }
    }
}
