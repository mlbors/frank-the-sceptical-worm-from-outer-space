/**
 * FTSWFOS - FrontComputer - Concrete Class
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

/**************************/
/***** FRONT COMPUTER *****/
/**************************/

public class FrontComputer : AbstractEnvironmentObjectComputer<IEnvironmentObject>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     */

    public FrontComputer() : base()
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
        _GenerateObject();
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** GENERATE OBJECT *****/
    /***************************/

    /**
     * @access protected
     */

    protected void _GenerateObject()
    {
        _generatedObjects = new Stack<IEnvironmentObject>();

        (_pool as IEnvironmentObjectPool).NeedType = EnvironmentObjectType.Front;
        _currentObject = _pool.GetObject();
        _currentObject.FollowedObject = _referenceObject;
        (_currentObject as MonoBehaviour).transform.position = _ComputePosition();
        (_currentObject as MonoBehaviour).gameObject.SetActive(true);
        _generatedObjects.Push(_currentObject);
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
        float zPosition = _ComputeZPosition();

        Vector3 position = new Vector3(xPosition, yPosition, zPosition);
        _currentObject.X = xPosition;
        _currentObject.Y = yPosition;
        _currentObject.Z = zPosition;

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
        float xPosition = 0.00f;
        xPosition = _referenceObject.transform.position.x;
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
        float yPosition = 0.00f;
        yPosition = _referenceObject.transform.position.y;
        return yPosition;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** COMPUTE Z POSITION *****/
    /******************************/

    /**
     * @access protected
     * @return float
     */

    protected float _ComputeZPosition()
    {
        float zPosition = 0.00f;
        zPosition = 3.00f;
        return zPosition;
    }
}
