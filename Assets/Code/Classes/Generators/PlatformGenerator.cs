/**
 * FTSWFOS - PlatformGenerator - Concrete Class
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

/******************************/
/***** PLATFORM GENERATOR *****/
/******************************/

public class PlatformGenerator : AbstractGeneratorComposite<IPlatform>, IPlatformGenerator, IObserver
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var float _maxYPosition max Y position
     * @var float _minYPosition min Y position
     * @var float _maxYGape max Y gape
     * @var float _minYGape min Y gape
     * @var float _maxXGape max X gape
     * @var float _minXGape min X gape
     * @var float _distanceBetween distance between platforms
     */

    protected float _maxYPosition = 4.50f;
    protected float _minYPosition = -2.25f;
    protected float _maxYGape = 4.50f;
    protected float _minYGape = -2.25f;
    protected float _maxXGape = 8.75f;
    protected float _minXGape = 4.25f;
    protected float _distanceBetween;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    public PlatformGenerator() : base()
    {
        _SetValues();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
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
        _InitPool();
        _InitOperators();
    }

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** INIT POOL *****/
    /*********************/

    /**
     * @access protected
     */

    protected void _InitPool()
    {
        _pool.Init();
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** INIT OPERATORS *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _InitOperators()
    {
        foreach (IOperatorElement element in _operatorElements)
        {
            element.Init();

            IGenerator generator;

            switch (element.GetType().ToString())
            {
                case "FoeOperatorElement":
                    generator = (element as IGeneratorOperatorElement<IFoe>).Generator;
                    break;

                case "CollectableOperatorElement":
                    generator = (element as IGeneratorOperatorElement<ICollectable>).Generator;
                    break;

                default:
                    generator = (element as IGeneratorOperatorElement<IFoe>).Generator;
                    break;
            }

            (generator as IObservable).Attach(this);
        }
    }

    /**************************************************/
    /**************************************************/

    /***********************************************/
    /***** IPLATFORM EXECUTE OPERATOR ELEMENTS *****/
    /***********************************************/

    /**
     * @access public
     */

    public override void ExecuteOperatorElements()
    {
        foreach (IOperatorElement element in _operatorElements)
        {
            (element as IGeneratorComponentOperatorElement).RequiredAction = "generate";
            element.Operate();
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     */

    public void ObserverUpdate(ObservableEventType info, object data)
    {
        if (info == ObservableEventType.PlatformObjectAdded && _currentObject != null)
        {
            _currentObject.ObjectsData.Add((PlatformObjectData)data);
        }
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
            _currentObject = _pool.GetObject();
            (_currentObject as MonoBehaviour).transform.position = _ComputePosition();
            (_currentObject as MonoBehaviour).gameObject.SetActive(true);
            ExecuteOperatorElements();
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** COMPUTE POSITION *****/
    /****************************/

    /**
     * @access protected
     * @return Vector3
     */

    protected Vector3 _ComputePosition()
    {
        float xPosition = _ComputeXPosition();
        float yPosition = _ComputeYPosition();

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
     * @return float
     */

    protected float _ComputeXPosition()
    {
        _distanceBetween = UnityEngine.Random.Range(_minXGape, _maxXGape);
        float _objectWidth = (_currentObject as MonoBehaviour).gameObject.GetComponent<BoxCollider2D>().size.x;

        float temp = _referenceObject.gameObject.transform.position.x + (_objectWidth / 2);
        float xPosition = temp + _distanceBetween;
        return xPosition;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** COMPUTE Y POSITION *****/
    /******************************/

    /**
     * @access protected
     * @return float
     */

    protected float _ComputeYPosition()
    {
        float yPosition = (_currentObject as MonoBehaviour).transform.position.y + UnityEngine.Random.Range(_minYGape, _maxYGape);

        if (yPosition > _maxYPosition)
        {
            return _maxYPosition;
        }

        if (yPosition < _minYGape)
        {
            return _minYGape;
        }

        return yPosition;
    }
}
