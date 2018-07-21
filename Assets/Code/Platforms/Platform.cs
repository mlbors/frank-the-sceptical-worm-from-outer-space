﻿/**
 * FTSWFOS - Platform - Concrete Class
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
using Zenject;

/**************************************************/
/**************************************************/

/********************/
/***** PLATFORM *****/
/********************/

public class Platform : AbstractPlatform
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param GameObject gameObject platform's game object
     */

    [Inject]
    public override void Construct(GameObject gameObject)
    {
        base.Construct(gameObject);
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** IPLATFORM EXECUTE OPERATORS *****/
    /***************************************/

    /**
     * @access public
     */

    public override void ExecuteOperators()
    {
        
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ON TRIGGER ENTER 2D *****/
    /*******************************/

    /**
     * @access private
     */

    public override void OnTriggerEnter2D(Collision2D otherObject)
    {
        
    }
}
 