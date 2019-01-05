/**
 * FTSWFOS - NegativeBonusComputer - Concrete Class
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

/***********************************/
/***** NEGATIVE BONUS COMPUTER *****/
/***********************************/

public class NegativeBonusComputer : AbstractObjectComputer<ICollectable>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Array _gapes array of the different gapes between each object
     */

    protected float[] _gapes;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     */

    public NegativeBonusComputer() : base()
    {
    }

    /**************************************************/
    /**************************************************/

    /************************************************/
    /***** IOBJECT COMPUTER EXECUTE COMPUTATION *****/
    /************************************************/

    /**
     * @access public
     */

    public override void ExecuteComputation()
    {
        _GenerateNegativeBonuses();
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** GENERATE NEGATIVE BONUSES *****/
    /*************************************/

    /**
     * @access protected
     */

    protected void _GenerateNegativeBonuses()
    {
        int maxItem;

        _generatedObjects = new Stack<ICollectable>();

        IPlatform platform = (_referenceObject as IGeneratorOperatorElement<IPlatform>).Generator.CurrentObject;
        _platformType = platform.Type;

        switch (_platformType)
        {
            case PlatformType.One:
            case PlatformType.Two:
                maxItem = 1;
                break;

            case PlatformType.Four:
            case PlatformType.Five:
                maxItem = 2;
                break;

            case PlatformType.Seven:
            case PlatformType.Nine:
                maxItem = 3;
                break;

            default:
                maxItem = 1;
                break;
        }

        System.Random rnd = new System.Random();
        int amount = rnd.Next(0, maxItem);

        if (amount == 0)
        {
            return;
        }

        for (int i = 0; i < amount; i++)
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
        float xPosition = 0.00f;
        float offset = 0.00f;
        float platformWidth = (platform as MonoBehaviour).gameObject.GetComponent<BoxCollider2D>().size.x;
        float platformPosition = (platform as MonoBehaviour).transform.position.x - platformWidth / 2.00f;
        float currentObjectWidth = (_currentObject as MonoBehaviour).gameObject.GetComponent<CircleCollider2D>().radius * 2.00f * 0.15f;

        if (_generatedObjects.Count == 0 && index == 0)
        {
            float position = 0.00f;
            float sumOfGapes = 0.00f;
            float neededSpace = 0.00f;
            float delta = 0.00f;
            float minPosition = platformPosition + (currentObjectWidth / 2.00f);
            float maxPosition = (platformPosition + platformWidth) - (currentObjectWidth / 2.00f);

            do
            {
                _gapes = new float[numberOfItem + 1];
                sumOfGapes = 0.00f;

                for (int i = 0; i <= numberOfItem; i++)
                {
                    position = UnityEngine.Random.Range(minPosition, maxPosition);
                    delta = position - platformPosition;

                    _gapes[i] = UnityEngine.Random.Range(currentObjectWidth * 1.50f, currentObjectWidth * 5.50f);
                    sumOfGapes += _gapes[i];
                }

                neededSpace = delta + sumOfGapes + (currentObjectWidth * numberOfItem);
            } while (neededSpace > platformWidth);

            xPosition = position;
        }

        if (index > 0 && _generatedObjects.Count > 0)
        {
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
        float minPosition = platformPosition + platformHeight;
        float maxPosition = platformPosition + platformHeight * 2.00f;

        yPosition = UnityEngine.Random.Range(minPosition, maxPosition);

        return yPosition;
    }
}
