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
    /**
     * @var CollectableType _lastCollectableType type of the last generated object
     * @var CollectableType _currentType type of the current generated object
     * @var Stack _generatedObjects stack of generated objects
     * @var Array _gapes array of the different gapes between each object
     */

    protected CollectableType _lastCollectableType = CollectableType.Death;
    protected CollectableType _currentType = CollectableType.Death;
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

        _lastCollectableType = _currentType;
        _currentType = _GetRandomCollectableType();
        (_pool as ICollectablePool).NeedType = _currentType;

        Debug.Log(_currentType);

        switch(_currentType)
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
                maxItem = 2;
                break;
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

        if (amount == 0) {
            return;
        }

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
        float platformPosition = (platform as MonoBehaviour).transform.position.x - platformWidth / 2.00f;
        float currentObjectWidth = (_currentObject as MonoBehaviour).gameObject.GetComponent<CircleCollider2D>().radius * 2.00f * 0.15f;

        if (_generatedObjects.Count == 0 && index == 0)
        {
            Debug.Log("First bonus");
            Debug.Log($"platform width: {platformWidth}");
            Debug.Log($"platform position: {platformPosition}");
            Debug.Log($"current object width: {currentObjectWidth}");

            float position = 0.00f;
            float sumOfGapes = 0.00f;
            float neededSpace = 0.00f;
            float delta = 0.00f;
            float minPosition =  platformPosition + (currentObjectWidth / 2.00f);
            float maxPosition = (platformPosition + platformWidth) - (currentObjectWidth / 2.00f);

            Debug.Log($"min position: {minPosition}");
            Debug.Log($"max position: {maxPosition}");

            do
            {
                _gapes = new float[numberOfItem + 1];
                sumOfGapes = 0.00f;

                // TO DO: fix this/improve
                for (int i = 0; i <= numberOfItem; i++)
                {
                    position = UnityEngine.Random.Range(minPosition, maxPosition);
                    delta = position - platformPosition;
                
                    _gapes[i] = UnityEngine.Random.Range(currentObjectWidth / 8.00f, currentObjectWidth / 2.00f);
                    sumOfGapes += _gapes[i];
                }

                neededSpace = delta + sumOfGapes + (currentObjectWidth * numberOfItem);

                Debug.Log($"position: {position}");
                Debug.Log($"delta: {delta}");
                Debug.Log($"needed space: {neededSpace}");
                Debug.Log($"array gapes: {_gapes.Length}");
            } while (neededSpace > platformWidth);

            xPosition = position;
        }

        if (index > 0 && _generatedObjects.Count > 0)
        {
            Debug.Log("Other bonus");
            Debug.Log($"Index: {index}");

            ICollectable previousObject = _generatedObjects.Peek();
            offset = previousObject.X;
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
        float platformHeight = (platform as MonoBehaviour).gameObject.GetComponent<BoxCollider2D>().size.y;

        yPosition = platformPosition + platformHeight * 1.50f;

        return yPosition;
    }
}
