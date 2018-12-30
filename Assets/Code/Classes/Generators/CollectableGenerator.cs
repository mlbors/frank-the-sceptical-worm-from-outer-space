/**
 * FTSWFOS - CollectableGenerator - Concrete Class
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

/*********************************/
/***** COLLECTABLE GENERATOR *****/
/*********************************/

public class CollectableGenerator : AbstractGenerator<ICollectable>, ICollectableGenerator
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var CollectableType _lastCollectableType type of the last generated object
     * @var CollectableType _currentType type of the current generated object
     * @var IObjectComputer _objectComputer contains algorithm to compute required object
     * @var IObjectComputerFactory _objectComputerFactory object that create other objects, here, IObjectComputer
     */

    protected CollectableType _lastCollectableType = CollectableType.Death;
    protected CollectableType _currentType = CollectableType.Death;
    protected IObjectComputer _objectComputer;
    protected IObjectComputerFactory<IObjectComputer> _objectComputerFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    public CollectableGenerator(IObjectComputerFactory<IObjectComputer> objectComputerFactory) : base()
    {
        _objectComputerFactory = objectComputerFactory;
    }

    /**************************************************/
    /**************************************************/

    /*****************************************/
    /***** OBJECT COMPUTER GETTER/SETTER *****/
    /*****************************************/

    public IObjectComputer ObjectComputer
    {
        get { return _objectComputer; }
        set { _objectComputer = value; }
    }

    /**************************************************/
    /**************************************************/

    /*************************************************/
    /***** OBJECT COMPUTER FACTORY GETTER/SETTER *****/
    /*************************************************/

    public IObjectComputerFactory<IObjectComputer> ObjectComputerFactory
    {
        get { return _objectComputerFactory; }
        set { _objectComputerFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /****************/
    /***** INIT *****/
    /****************/

    /**
     * @access public
     */

    public override void Init()
    {
        _pool.Init();

        _objectComputerFactory.Type = ObjectComputerType.Bonus;
        _objectComputer = _objectComputerFactory.Create();
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public override void Generate()
    {
        try 
        {
            _lastCollectableType = _currentType;
            _currentType = _GetRandomCollectableType();
            (_pool as ICollectablePool).NeedType = _currentType;

            switch (_currentType)
            {
                case CollectableType.Bonus:
                    _GenerateBonuses();
                    break;
                case CollectableType.Death:
                    break;
                case CollectableType.NegativeBonus:
                    break;
                case CollectableType.PowerUp:
                    break;
                default:
                    _GenerateBonuses();
                    break;
            }
        }
        catch (Exception e)
        {
            Debug.Log($"Exception thrown: {e.Message}");
        }
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** GET RANDOM COLLECTABLE TYPE *****/
    /***************************************/

    /**
     * @access protected
     * @return CollectableType
     */

    protected CollectableType _GetRandomCollectableType()
    {
        if (_lastCollectableType != CollectableType.Bonus)
        {
            return CollectableType.Bonus;
        }

        Array values = Enum.GetValues(typeof(CollectableType));
        System.Random random = new System.Random();
        return (CollectableType)values.GetValue(random.Next(values.Length));
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** GENERATE BONUSES *****/
    /****************************/

    /**
     * @access protected
     */

    protected void _GenerateBonuses()
    {
        (_objectComputer as IObjectComputer<ICollectable>).Pool = _pool;
        _objectComputer.ReferenceObject = _referenceObject;
        _objectComputer.ExecuteComputation();
    }
}
