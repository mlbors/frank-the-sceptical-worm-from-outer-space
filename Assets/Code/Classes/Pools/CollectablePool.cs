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
     * @var IOperator _gameOperator object managing game        
     * @var IOperatorElement _scoreOperator object managing score     
     */

    protected CollectableType _neededType;
    protected IOperator _gameOperator;
    protected IOperatorElement _scoreOperator;

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

    /***************************************/
    /***** GAME OPERATOR GETTER/SETTER *****/
    /***************************************/

    public IOperator GameOperator
    {
        get { return _gameOperator; }
        set { _gameOperator = value; }
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** SCORE OPERATOR GETTER/SETTER *****/
    /****************************************/

    public IOperatorElement ScoreOperator
    {
        get { return _scoreOperator; }
        set { _scoreOperator = value; }
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
        _CheckFactoryScoreOperator();
        FillPool();
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IPOOL GET OBJECT *****/
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
        _CheckFactory();
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

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** CHECK FACTORY *****/
    /*************************/

    /**
     * @access protected
     */

    protected void _CheckFactory()
    {
        _CheckFactoryGameOperator();
        _CheckFactoryScoreOperator();
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** CHECK FACTORY GAME OPERATOR *****/
    /***************************************/

    /**
     * @access protected
     */

    protected void _CheckFactoryGameOperator()
    {
        if ((_factory as ICollectableFactory<ICollectable>).GameOperator == null)
        {
            (_factory as ICollectableFactory<ICollectable>).GameOperator = _gameOperator;
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** CHECK FACTORY SCORE OPERATOR *****/
    /****************************************/

    /**
     * @access protected
     */

    protected void _CheckFactoryScoreOperator()
    {
        if ((_factory as ICollectableFactory<ICollectable>).ScoreOperator == null)
        {
            (_factory as ICollectableFactory<ICollectable>).ScoreOperator = _scoreOperator;
        }
    }
}
