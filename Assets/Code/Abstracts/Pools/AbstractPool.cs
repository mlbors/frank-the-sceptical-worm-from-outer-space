/**
 * FTSWFOS - AbstractPool - Abstract Class
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
/***** ABSTRACT POOL *****/
/*************************/

abstract public class AbstractPool<T> : IPool<T>, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var T _pooledObject current pooled object
     * @var List<T> _pooledObjects list of all objects in the pool
     * @var Int _amount initinal amount
     * @var IFactory _factory object that creates other objects, here object of type T
     */

    protected T _pooledObject;
    protected List<T> _pooledObjects = new List<T>();
    protected int _amount;
    protected IFactory<T> _factory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param Int amount initinal amount
     * @param IFactory factory object that other creates objects, here object of type T
     */

    protected AbstractPool(int amount, IFactory<T> factory)
    {
        _amount = amount;
        _factory = factory;
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** POOLED OBJECT GETTER/SETTER *****/
    /***************************************/

    /**
     * @access public
     */

    public T PooledObject
    {
        get { return _pooledObject; }
        set { _pooledObject = value; }
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** POOLED OBJECTS GETTER/SETTER *****/
    /****************************************/

    /**
     * @access public
     */

    public List<T> PooledObjects
    {
        get { return _pooledObjects; }
        set { _pooledObjects = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** AMOUNT GETTER/SETTER *****/
    /********************************/

    /**
     * @access public
     */

    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** FACTORY GETTER/SETTER *****/
    /*********************************/

    /**
     * @access public
     */

    public IFactory<T> Factory
    {
        get { return _factory; }
        set { _factory = value; }
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** IPOOL INIT *****/
    /**********************/

    /**
     * @access public
     */

    public abstract void Init();

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** IPOOL INSTANTIATE NEW OBJECT *****/
    /****************************************/

    /**
     * @access public
     * @return T
     */

    public abstract T InstantiateNewObject();

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IPOOL ADD OBJECT *****/
    /****************************/

    /**
     * @access public
     * @param GameObject pooledObject object to add
     */

    public void AddObject(T pooledObject)
    {
        _pooledObjects.Add(pooledObject);
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** IPOOL REMOVE OBJECT *****/
    /*******************************/

    /**
     * @access public
     * @param GameObject pooledObject object to remove
     */

    public void RemoveObject(T pooledObject)
    {
        _pooledObjects.Remove(pooledObject);
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IPOOL ADD OBJECT *****/
    /****************************/

    /**
     * @access public
     */

    public virtual void FillPool()
    {
        for (int i = 0; i < _amount; i++)
        {
            Debug.Log("::: FillPool :::");
            _pooledObject = InstantiateNewObject();
            AddObject(_pooledObject);
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IPOOL GET OBEJCT *****/
    /****************************/

    /**
     * @access public
     * @return T
     */

    public virtual T GetObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (CheckIfObjectAvailable(_pooledObjects[i]))
            {
                return _pooledObjects[i];
            }
        }

        var newObj = InstantiateNewObject();
        AddObject(newObj);
        return newObj;
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** IPOOL CHECK IF OBJECT AVAILABLE *****/
    /*******************************************/

    /**
     * @access public
     * @param T currentObject object to check
     * @return Bool
     */

    public abstract bool CheckIfObjectAvailable(T currentObject);
}
