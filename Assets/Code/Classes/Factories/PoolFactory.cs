/**
 * FTSWFOS - PoolFactory - Concrete Class
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

/************************/
/***** POOL FACTORY *****/
/************************/

public class PoolFactory : AbstractDIFactory<IPool>, IPoolFactory<IPool>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var PoolTypes _type type of pool
     */

    protected PoolTypes _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param PoolTypes type type of pool
     */

    public PoolFactory(DiContainer container, PoolTypes type = PoolTypes.Platform) : base(container)
    {
        _type = type;
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** TYPES GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public PoolTypes Type
    {
        get { return _type; }
        set { _type = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return IPool
     */

    public override IPool Create(params object[] constructorArguments)
    {
        IPool pool;

        switch (_type)
        {
            case PoolTypes.Platform:
                pool = _container.Instantiate<PlatformPool>() as IPool;
                break;
            default:
                pool = _container.Instantiate<PlatformPool>() as IPool;
                break;
        }

        return pool;
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** IVALIDATABLE VALIDATABLE *****/
    /************************************/

    /**
     * @access public
     */

    public override void Validate()
    {
        _container.Instantiate<PlatformPool>();
    }
}