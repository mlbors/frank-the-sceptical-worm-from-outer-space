/**
 * FTSWFOS - AbstractMenu - Abstract Class
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

/*************************/
/***** ABSTRACT MENU *****/
/*************************/

abstract public class AbstractMenu : MonoBehaviour, IMenu, IProduct
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    [Inject]
    public virtual void Construct()
    {
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** IMENU ACTIVATE *****/
    /**************************/

    /**
     * @access public
     */

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IMENU DEACTIVATE *****/
    /****************************/

    /**
     * @access public
     */

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
