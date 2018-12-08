/**
 * FTSWFOS - CollectablePool - Concrete Class
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

/****************************/
/***** COLLECTABLE POOL *****/
/****************************/

public class CollectablePool : AbstractPool<ICollectable>, ICollectablePool
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var CollectableType _neededType type of collectable needed
     */

    protected CollectableType _neededType;

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

    public CollectablePool(ICollectableFactory<ICollectable> factory, int amount = 5) : base(amount, factory)
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

    public CollectableType NeedType
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
        _neededType = CollectableType.Bonus;
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

    public override ICollectable GetObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (CheckIfObjectAvailable(_pooledObjects[i])
                && (_pooledObjects[i] as ICollectable).Type == _neededType)
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
     * @return ICollectable
     */

    public override ICollectable InstantiateNewObject()
    {
        (_factory as ICollectableFactory<ICollectable>).Type = _neededType;

        ICollectable collectable = _factory.Create();

        (collectable as MonoBehaviour).gameObject.SetActive(false);
        return collectable;
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** IPOOL CHECK IF OBJECT AVAILABLE *****/
    /*******************************************/

    /**
     * @access public
     * @param ICollectable currentObject object to check
     * @return Bool
     */

    public override bool CheckIfObjectAvailable(ICollectable currentObject)
    {
        return !(currentObject as MonoBehaviour).gameObject.activeInHierarchy;
    }
}
