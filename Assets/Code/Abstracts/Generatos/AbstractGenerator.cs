/**
 * FTSWFOS - AbstractGenerator - Abstract Class
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
/***** ABSTRACT GENERATOR *****/
/******************************/

abstract public class AbstractGenerator<T> : IGenerator<T>, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IPool _pool objects pool
     * @var IPoolFactory _poolFactory factory object that creates other objects, here, IPool
     */

    protected IPool<T> _pool;
    protected IPoolFactory<IPool> _poolFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param IPoolFactory _poolFactory factory object that creates other objects, here, IPool
     */

    protected AbstractGenerator(IPoolFactory<IPool> poolFactory)
    {
        PoolFactory = poolFactory;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** POOL GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public IPool<T> Pool
    {
        get { return _pool; }
        set { _pool = value; }
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** POOL FACTORY GETTER/SETTER *****/
    /**************************************/

    /**
     * @access public
     */

    public IPoolFactory<IPool> PoolFactory
    {
        get { return _poolFactory; }
        set { _poolFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public abstract void Generate();
}
