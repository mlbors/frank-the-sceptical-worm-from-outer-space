/**
 * FTSWFOS - AbstractPool - Abstract Class
 *
 * @since       09.01.2018
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

abstract public class AbstractPool : IPool
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var GameObject _pooledObject current pooled object
     * @var List<GameObject> _pooledObjects list of all objects in the pool
     * @var Int _amount initinal amount
     */

    protected GameObject _pooledObject;
    protected List<GameObject> _pooledObjects;
    protected int _amount;

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** POOLED OBJECT GETTER/SETTER *****/
    /***************************************/

    /*
     * @access public
     */

    public GameObject PooledObject
    {
        get { return _pooledObject; }
        set { _pooledObject = value; }
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** POOLED OBJECTS GETTER/SETTER *****/
    /****************************************/

    /*
     * @access public
     */

    public List<GameObject> PooledObjects
    {
        get { return _pooledObjects; }
        set { _pooledObjects = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** AMOUNT GETTER/SETTER *****/
    /********************************/

    /*
     * @access public
     */

    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
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

    /****************************/
    /***** IPOOL ADD OBJECT *****/
    /****************************/

    /**
     * @access public
     * @param GameObject pooledObject object to add
     */

    public void AddObject(GameObject pooledObject)
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

    public void RemoveObject(GameObject pooledObject)
    {
        _pooledObjects.Remove(pooledObject);
    }
}
