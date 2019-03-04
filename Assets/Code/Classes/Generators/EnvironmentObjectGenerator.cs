﻿/**
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

    /**
     * @var IObjectComputer _objectComputer contains algorithm to compute required object
     * @var IObjectComputerFactory _objectComputerFactory object that create other objects, here, IObjectComputer
     * @var Dictionary<string, IObjectComputer> _objectComputers dictionary of needed various object computers
     */

    protected IObjectComputer _objectComputer;
    protected IObjectComputerFactory<IObjectComputer> _objectComputerFactory;
    protected Dictionary<string, IObjectComputer> _objectComputers = new Dictionary<string, IObjectComputer>();

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IObjectComputerFactory objectComputerFactory object that create other objects, here, IObjectComputer
     */

    public EnvironmentObjectGenerator(IObjectComputerFactory<IObjectComputer> objectComputerFactory) : base()
    {
        _objectComputerFactory = objectComputerFactory;
    }

    /**************************************************/
    /**************************************************/

    /*****************************************/
    /***** OBJECT COMPUTER GETTER/SETTER *****/
    /*****************************************/

    public IObjectComputer ObjectComputer
    {
        get { return _objectComputer; }
        set { _objectComputer = value; }
    }

    /**************************************************/
    /**************************************************/

    /*************************************************/
    /***** OBJECT COMPUTER FACTORY GETTER/SETTER *****/
    /*************************************************/

    public IObjectComputerFactory<IObjectComputer> ObjectComputerFactory
    {
        get { return _objectComputerFactory; }
        set { _objectComputerFactory = value; }
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

        _objectComputerFactory.Type = ObjectComputerType.Back;
        _objectComputers["back"] = _objectComputerFactory.Create();

        _objectComputerFactory.Type = ObjectComputerType.Front;
        _objectComputers["front"] = _objectComputerFactory.Create();

        _objectComputerFactory.Type = ObjectComputerType.Middle;
        _objectComputers["middle"] = _objectComputerFactory.Create();
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