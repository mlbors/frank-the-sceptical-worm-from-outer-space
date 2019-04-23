/**
 * FTSWFOS - Front - Conrete Class
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

/*****************/
/***** FRONT *****/
/*****************/

public class Front : AbstractEnvironmentObject
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Bool _increase position will increase or decrease
     */

    protected bool _increase = true;

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
            float x = transform.position.x;

            if (_increase)
            {
                if (x < _followedObject.transform.position.x + 6.75f)
                {
                    x = _followedObject.transform.position.x + 0.045f;
                }
                else
                {
                    _increase = false;
                }

            }

            if (!_increase)
            {
                if (x > _followedObject.transform.position.x - 6.75f)
                {
                    x = _followedObject.transform.position.x - 0.045f;
                }
                else
                {
                    _increase = true;
                }

            }

            transform.position = new Vector3(x, _followedObject.transform.position.y, transform.position.z);
        }
        catch (Exception e)
        {
            Logger.LogMessage(e);
        }
    }
}
 