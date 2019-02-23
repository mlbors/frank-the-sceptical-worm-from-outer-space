/**
 * FTSWFOS - EnvironmentObjectPool - Concrete Class
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

/***********************************/
/***** ENVIRONMENT OBJECT POOL *****/
/***********************************/

public class EnvironmentObjectPool : AbstractPool<IEnvironmentObject>, IEnvironmentObjectPool
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var EnvironmentObjectType _neededType type of environment object needed
     */

    protected EnvironmentObjectType _neededType;

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

    public EnvironmentObjectPool(IEnvironmentObjectFactory<IEnvironmentObject> factory, int amount = 5) : base(amount, factory)
    {
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** NEEDED TYPE GETTER/SETTER *****/
    /*************************************/

    /**
     * @access public
     */

    public EnvironmentObjectType NeedType
    {
        get { return _neededType; }
        set { _neededType = value; }
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
        _neededType = EnvironmentObjectType.Back;
        FillPool();
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IPOOL GET OBEJCT *****/
    /****************************/

    /**
     * @access public
     * @return ICollectable
     */

    public override IEnvironmentObject GetObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (CheckIfObjectAvailable(_pooledObjects[i])
                && (_pooledObjects[i] as IEnvironmentObject).Type == _neededType)
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

    /****************************************/
    /***** IPOOL INSTANTIATE NEW OBJECT *****/
    /****************************************/

    /**
     * @access public
     * @return IEnvironmentObject
     */

    public override IEnvironmentObject InstantiateNewObject()
    {
        (_factory as IEnvironmentObjectFactory<IEnvironmentObject>).Type = _neededType;

        IEnvironmentObject environmentObject = _factory.Create();

        (environmentObject as MonoBehaviour).gameObject.SetActive(false);
        return environmentObject;
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** IPOOL CHECK IF OBJECT AVAILABLE *****/
    /*******************************************/

    /**
     * @access public
     * @param IEnvironmentObject currentObject object to check
     * @return Bool
     */

    public override bool CheckIfObjectAvailable(IEnvironmentObject currentObject)
    {
        return !(currentObject as MonoBehaviour).gameObject.activeInHierarchy;
    }
}
