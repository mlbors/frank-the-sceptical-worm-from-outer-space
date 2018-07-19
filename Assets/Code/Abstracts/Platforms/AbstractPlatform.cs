/**
 * FTSWFOS - AbstractPlatform - Abstract Class
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
using Zenject;

/**************************************************/
/**************************************************/

/*****************************/
/***** ABSTRACT PLATFORM *****/
/*****************************/

abstract public class AbstractPlatform : MonoBehaviour, IPlatform, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var GameObject _gameObject player's game object
     * @var List<IOperator> _operators list of operators to generate various components
     * @var Float _x x position
     * @var Float _y y position;
     */

    protected GameObject _gameObject;
    protected List<IOperator> _operators = new List<IOperator>();
    protected float _x;
    protected float _y;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param GameObject gameObject platform's game object
     */

    [Inject]
    public virtual void Construct(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    /**************************************************/
    /**************************************************/

    /***********************************/
    /***** OPERATORS GETTER/SETTER *****/
    /***********************************/

    /**
     * @access public
     */

    public List<IOperator> Operators
    {
        get { return _operators; }
        set { _operators = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** X GETTER/SETTER *****/
    /***************************/

    /**
     * @access public
     */

    public float X
    {
        get { return _x; }
        set { _x = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** Y GETTER/SETTER *****/
    /***************************/

    /**
     * @access public
     */

    public float Y
    {
        get { return _y; }
        set { _y = value; }
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** IPLATFORM ADD OPERATOR *****/
    /**********************************/

    /**
     * @access public
     * @param IOperator operatorElement opertaor to add
     */

    public void AddOperator(IOperator operatorElement)
    {
        _operators.Add(operatorElement);
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** IPLATFORM REMOVE OPERATOR *****/
    /*************************************/

    /**
     * @access public
     * @param IOperator operatorElement opertaor to remove
     */

    public void RemoveOperator(IOperator operatorElement)
    {
        _operators.Remove(operatorElement);
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** IPLATFORM EXECUTE OPERATORS *****/
    /***************************************/

    /**
     * @access public
     */

    public abstract void ExecuteOperators();

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ON TRIGGER ENTER 2D *****/
    /*******************************/

    /**
     * @access private
     */

    public abstract void OnTriggerEnter2D(Collision2D otherObject);
}
 