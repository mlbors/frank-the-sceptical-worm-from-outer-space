/**
 * FTSWFOS - PlatformPool - Concrete Class
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

/*************************/
/***** PLATFORM POOL *****/
/*************************/

public class PlatformPool : AbstractPool<IPlatform>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var PlatformType _neededType type of platform needed
     */

    protected PlatformType _neededType;

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

    public PlatformPool(IPlatformFactory<IPlatform> factory, int amount = 5) : base(amount, factory)
    {
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
        (_factory as IPlatformFactory<IPlatform>).Type = PlatformType.One;
        FillPool();
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IPOOL ADD OBJECT *****/
    /****************************/

    /**
     * @access public
     */

    public override void FillPool()
    {
        for (int i = 0; i < _amount; i++)
        {
            Debug.Log("::: FillPool :::");
            _neededType = _GetRandomPlatformType();
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
     * @return IPlatform
     */

    public override IPlatform GetObject()
    {
        PlatformType platformType = _GetRandomPlatformType();

        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (CheckIfObjectAvailable(_pooledObjects[i]) 
                && (_pooledObjects[i] as IPlatform).Type == platformType)
            {
                return _pooledObjects[i];
            }
        }

        _neededType = platformType;
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
     * @return IPlatform
     */

    public override IPlatform InstantiateNewObject()
    {
        (_factory as IPlatformFactory<IPlatform>).Type = _neededType;

        IPlatform platform = _factory.Create();

        (platform as MonoBehaviour).gameObject.SetActive(false);
        return platform;
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** IPOOL CHECK IF OBJECT AVAILABLE *****/
    /*******************************************/

    /**
     * @access public
     * @param IPlatform currentObject object to check
     * @return Bool
     */

    public override bool CheckIfObjectAvailable(IPlatform currentObject)
    {
        return !(currentObject as MonoBehaviour).gameObject.activeInHierarchy;
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** GET RANDOM PLATFORM TYPE *****/
    /************************************/

    /**
     * @access protected
     * @return PlatformType
     */

    protected PlatformType _GetRandomPlatformType()
    {
        Array values = Enum.GetValues(typeof(PlatformType));
        System.Random random = new System.Random();
        PlatformType platformType = (PlatformType)values.GetValue(random.Next(values.Length));
        return platformType;
    }
}
