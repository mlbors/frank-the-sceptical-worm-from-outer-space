﻿/**
 * FTSWFOS - PlatformPool - Concrete Class
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

/*************************/
/***** PLATFORM POOL *****/
/*************************/

public class PlatformPool : AbstractPool<IPlatform>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param T pooledObject current pooled object
     * @param Int amount initinal amount
     * @param IFactory factory object that other creates objects, here object of type T
     */

    public PlatformPool(IPlatform pooledObject, int amount, IPlatformFactory<IPlatform> factory) : base(pooledObject, amount, factory)
    {
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** IPOOL INIT *****/
    /**********************/

    /**
     * @access public
     */

    public override void Init()
    {
        FillPool();
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** IPOOL INSTANTIATE NEW OBJECT *****/
    /****************************************/

    /**
     * @access public
     * @return IPlatform
     */

    public override IPlatform InstantiateNewObject()
    {
        IPlatform platform = _factory.Create();
        (platform as MonoBehaviour).gameObject.SetActive(false);
        return platform;
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** IPOOL CHECK IF OBJECT AVAILABLE *****/
    /*******************************************/

    /**
     * @access public
     * @param IPlatform currentObject object to check
     * @return Bool
     */

    public override bool CheckIfObjectAvailable(IPlatform currentObject)
    {
        return (currentObject as MonoBehaviour).gameObject.activeInHierarchy;
    }
}