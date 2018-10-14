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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************/
/**************************************************/

/******************************/
/***** PLATFORM GENERATOR *****/
/******************************/

public class PlatformGenerator : AbstractGeneratorComposite<IPlatform>, IPlatformGenerator
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
     * @var IPlatform _currentObject current generated object
     */

    protected float _maxYPosition = 10.00f;
    protected float _minYPosition = 0.50f;
    protected float _maxYGape = 2.50f;
    protected float _minYGape = 1.05f;
    protected float _maxXGape = 1.75f;
    protected float _minXGape = 0.50f;
    protected float _distanceBetween;
    protected IPlatform _currentObject;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IOperatorElementFactory<IOperatorElement> operatorElementFactory object that create other objects, here, IOperatorElementFactory
     */

    public PlatformGenerator(IOperatorElementFactory<IOperatorElement> operatorElementFactory,
                             IPoolFactory<IPool> poolFactory) : base(operatorElementFactory, poolFactory)
    {
        _SetValues();
        _InitPool();
        _InitOperators();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        _operatorElementFactory.Type = OperatorElementType.CollectableOperatorElement;
        AddOperatorElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementType.FoeOperatorElement;
        AddOperatorElement(_operatorElementFactory.Create());

        _poolFactory.Type = PoolType.Platform;
        _pool = _poolFactory.Create() as IPool<IPlatform>;
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
            element.Operate();
        }
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public override void Generate()
    {
        _currentObject = _pool.GetObject();
        (_currentObject as MonoBehaviour).transform.position = _ComputePosition();
        (_currentObject as MonoBehaviour).gameObject.SetActive(true);
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
        _distanceBetween = Random.Range(_minXGape, _maxXGape);
        float _objectWidth = (_currentObject as MonoBehaviour).GetComponent<BoxCollider2D>().size.x;

        float temp = (_currentObject as MonoBehaviour).transform.position.x + (_objectWidth / 2);
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

        float yPosition = (_currentObject as MonoBehaviour).transform.position.y + Random.Range(_maxYGape, -_maxYGape);

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
