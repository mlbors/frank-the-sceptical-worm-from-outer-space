﻿/**
 * FTSWFOS - PlatformGenerator - Concrete Class
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

/******************************/
/***** PLATFORM GENERATOR *****/
/******************************/

public class PlatformGenerator : AbstractGeneratorComposite<IPlatform>, IPlatformGenerator
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IOperatorElementFactory<IOperatorElement> operatorElementFactory object that create other objects, here, IOperatorElementFactory
     */

    public PlatformGenerator(IOperatorElementFactory<IOperatorElement> operatorElementFactory,
                             IPoolFactory<IPool> poolFactory) : base(operatorElementFactory, poolFactory)
    {
        _SetValues();
        _InitPool();
        _InitOperators();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        _operatorElementFactory.Type = OperatorElementType.CollectableOperatorElement;
        AddOperatorElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementType.FoeOperatorElement;
        AddOperatorElement(_operatorElementFactory.Create());

        _poolFactory.Type = PoolType.Platform;
        _pool = _poolFactory.Create() as IPool<IPlatform>;
    }

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** INIT POOL *****/
    /*********************/

    /**
     * @access protected
     */

    protected void _InitPool()
    {
        _pool.Init();
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** INIT OPERATORS *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _InitOperators()
    {
        foreach (IOperatorElement element in _operatorElements)
        {
            element.Init();
        }
    }

    /**************************************************/
    /**************************************************/

    /***********************************************/
    /***** IPLATFORM EXECUTE OPERATOR ELEMENTS *****/
    /***********************************************/

    /**
     * @access public
     */

    public override void ExecuteOperatorElements()
    {
        foreach (IOperatorElement element in _operatorElements)
        {
            element.Operate();
        }
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public override void Generate()
    {

    }
}
