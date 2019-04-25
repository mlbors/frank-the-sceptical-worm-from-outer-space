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

    /**
     * @var IObjectComputer _objectComputer contains algorithm to compute required object
     * @var IObjectComputerFactory _objectComputerFactory object that create other objects, here, IObjectComputer
     * @var Dictionary<string, IObjectComputer> _objectComputers dictionary of needed various object computers
     * @var Bool _ahsRun tells if the generator has already be run 
     */

    protected IObjectComputer _objectComputer;
    protected IObjectComputerFactory<IObjectComputer> _objectComputerFactory;
    protected Dictionary<string, IObjectComputer> _objectComputers = new Dictionary<string, IObjectComputer>();
    protected bool _hasRun;

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
        IObjectComputer backObjectComputer = _objectComputerFactory.Create();
        (backObjectComputer as IObjectComputer<IEnvironmentObject>).Pool = _pool;
        _objectComputers["back"] = backObjectComputer;

        _objectComputerFactory.Type = ObjectComputerType.Middle;
        IObjectComputer middleObjectComputer = _objectComputerFactory.Create();
        (middleObjectComputer as IObjectComputer<IEnvironmentObject>).Pool = _pool;
        _objectComputers["middle"] = middleObjectComputer;

        _objectComputerFactory.Type = ObjectComputerType.Front;
        IObjectComputer frontObjectComputer = _objectComputerFactory.Create();
        (frontObjectComputer as IObjectComputer<IEnvironmentObject>).Pool = _pool;
        _objectComputers["front"] = frontObjectComputer;
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
            if (_hasRun || _referenceObject == null)
            {
                return;
            }

            _objectComputers["back"].ReferenceObject = _referenceObject;
            _objectComputers["middle"].ReferenceObject = _referenceObject;
            _objectComputers["front"].ReferenceObject = _referenceObject;

            _objectComputers["back"].ExecuteComputation();
            _objectComputers["middle"].ExecuteComputation();
            _objectComputers["front"].ExecuteComputation();

            _hasRun = true;
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }
}
