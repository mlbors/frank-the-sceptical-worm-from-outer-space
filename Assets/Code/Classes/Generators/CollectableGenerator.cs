﻿/**
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
    /**
     * @var CollectableType _lastCollectableType type of the last generated object
     * @var Stack _generatedObjects stack of generated objects
     * @var Array _gapes array of the different gapes between each object
     */

    protected CollectableType _lastCollectableType = CollectableType.Death;
    protected Stack<ICollectable> _generatedObjects;
    protected float[] _gapes;

    /**************************************************/
    /**************************************************/

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
        Debug.Log("::: Generate collectable :::");

        _generatedObjects = new Stack<ICollectable>();

        CollectableType collectableType = _GetRandomCollectableType();
        _lastCollectableType = collectableType;
        (_pool as ICollectablePool).NeedType = collectableType;

        Debug.Log(collectableType);

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
            default:
                _GenerateBonuses();
                break;
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
        Debug.Log("::: Generate Bonus :::");

        int maxItem;

        IPlatform platform = (_referenceObject as IGeneratorOperatorElement<IPlatform>).Generator.CurrentObject;
        PlatformType platformType = platform.Type;

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
            (_currentObject as MonoBehaviour).transform.position = _ComputePosition(amount, platform, i);
            (_currentObject as MonoBehaviour).gameObject.SetActive(true);
            _generatedObjects.Push(_currentObject);
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** COMPUTE POSITION *****/
    /****************************/

    /**
     * @access protected
     * @param int numberOfItem number of generated objects
     * @param IPlatform platform platform used as a reference
     * @param int index generation index
     * @return Vector3
     */


    protected Vector3 _ComputePosition(int numberOfItem, IPlatform platform, int index)
    {
        float xPosition = _ComputeXPosition(numberOfItem, platform, index);
        float yPosition = _ComputeYPosition(numberOfItem, platform);

        Vector3 position = new Vector3(xPosition, yPosition, (_currentObject as MonoBehaviour).transform.position.z);
        _currentObject.X = xPosition;
        _currentObject.Y = yPosition;

        return position;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** COMPUTE X POSITION *****/
    /******************************/

    /**
     * @access protected
     * @param int numberOfItem number of generated objects
     * @param IPlatform platform platform used as a reference
     * @param int index generation index
     * @return float
     */

    protected float _ComputeXPosition(int numberOfItem, IPlatform platform, int index)
    {
        Debug.Log("::: Compute x position :::");

        float xPosition = 0.00f;
        float offset = 0.00f;
        float platformWidth = (platform as MonoBehaviour).gameObject.GetComponent<BoxCollider2D>().size.x;
        float platformPosition = (platform as MonoBehaviour).transform.position.x - platformWidth / 2;
        float currentObjectWidth = (_currentObject as MonoBehaviour).gameObject.GetComponent<CircleCollider2D>().radius * 2;

        // TO DO: fix this and the pool
        if (_generatedObjects.Count == 0 && index == 0)
        {
            float position = 0.00f;
            float sumOfGapes = 0.00f;
            float neededSpace = 0.00f;

            _gapes = new float[numberOfItem];

            while (neededSpace == 0.00f || neededSpace > platformWidth)
            {
                position = UnityEngine.Random.Range(platformPosition, platformPosition + platformWidth);

                for (int i = 0; i < numberOfItem; i++)
                {
                    _gapes[i] = UnityEngine.Random.Range(currentObjectWidth / 2, (platformWidth / numberOfItem) / 10);
                    sumOfGapes += _gapes[i];
                }

                neededSpace = position + sumOfGapes + (currentObjectWidth * numberOfItem);
                Debug.Log(neededSpace);
            }

            xPosition = position;
        }

        if (index > 0 && _generatedObjects.Count > 0)
        {
            ICollectable previousObject = _generatedObjects.Peek();
            float width = (previousObject as MonoBehaviour).gameObject.GetComponent<CircleCollider2D>().radius * 2;
            offset = previousObject.X + width;

            xPosition = offset + _gapes[index];
        }

        return xPosition;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** COMPUTE Y POSITION *****/
    /******************************/

    /**
     * @access protected
     * @param int numberOfItem number of generated objects
     * @param IPlatform platform platform used as a reference
     * @return float
     */


    protected float _ComputeYPosition(int numberOfItem, IPlatform platform)
    {
        float yPosition = 0.00f;
        float platformPosition = (platform as MonoBehaviour).transform.position.y;

        yPosition = platformPosition + 40.00f;

        return yPosition;
    }
}
