/**
 * FTSWFOS - Back - Conrete Class
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

/****************/
/***** BACK *****/
/****************/

public class Back : AbstractEnvironmentObject
{
    /*****************/
    /***** AWAKE *****/
    /*****************/

    /**
     * @access public
     */

    public override void Awake()
    {

    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access public
     */

    public override void Start()
    {

    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /**
     * @access public
     */

    public override void Update()
    {
        _MoveObject();
    }

    /**************************************************/
    /**************************************************/

    /***********************/
    /***** MOVE OBJECT *****/
    /***********************/

    /**
     * @access protected
     */

    protected void _MoveObject()
    {
        try
        {
            transform.position = new Vector3(_followedObject.transform.position.x, _followedObject.transform.position.y, transform.position.z);
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }
}
 