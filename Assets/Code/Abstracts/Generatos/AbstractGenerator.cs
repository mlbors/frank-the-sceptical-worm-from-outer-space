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
     * @var MonoBehaviour _referenceObject object used as a reference
     * @var IPool _pool objects pool
     * @var IPoolFactory _poolFactory factory object that creates other objects, here, IPool
     * @var IPlatform _currentObject current generated object
     */

    protected MonoBehaviour _referenceObject;
    protected IPool<T> _pool;
    protected IPoolFactory<IPool> _poolFactory;
    protected T _currentObject;

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

    /******************************************/
    /***** REFERENCE OBJECT GETTER/SETTER *****/
    /******************************************/

    /**
     * @access public
     */

    public MonoBehaviour ReferenceObject
    {
        get { return _referenceObject; }
        set { _referenceObject = value; }
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

    /****************************************/
    /***** CURRENT OBJECT GETTER/SETTER *****/
    /****************************************/

    /**
     * @access public
     */

    public T CurrentObject
    {
        get { return _currentObject; }
        set { _currentObject = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public abstract void Generate();
}
