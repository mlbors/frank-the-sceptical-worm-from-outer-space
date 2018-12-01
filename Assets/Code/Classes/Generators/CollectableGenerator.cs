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

public class CollectableGenerator : AbstractGenerator<ICollectable>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    public CollectableGenerator() : base()
    {
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
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public override void Generate()
    {
        CollectableType collectableType = _GetRandomCollectableType();
        (_pool as ICollectablePool).NeedType = collectableType;

        switch(collectableType)
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
        }

        _currentObject = _pool.GetObject();
        (_currentObject as MonoBehaviour).gameObject.SetActive(true);
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
        int maxItem;

        PlatformType platformType = (_referenceObject as IGeneratorOperatorElement<IPlatform>).Generator.CurrentObject.Type;

        switch (platformType)
        {
            case PlatformType.One:
            case PlatformType.Two:
                maxItem = 3;
                break;
            case PlatformType.Four:
            case PlatformType.Five:
                maxItem = 4;
                break;
            case PlatformType.Seven:
            case PlatformType.Nine:
                maxItem = 5;
                break;
            default:
                maxItem = 3;
                break;
        }

        System.Random rnd = new System.Random();
        int amount = rnd.Next(0, maxItem);

        for (int i = 0; i <= amount; i++)
        {
            _currentObject = _pool.GetObject();
            (_currentObject as MonoBehaviour).gameObject.SetActive(true);
        }
    }
}
