/**
 * FTSWFOS - AbstractOperator - Abstract Class
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

/*****************************/
/***** ABSTRACT OPERATOR *****/
/*****************************/

abstract public class AbstractOperator : IOperator, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IOperatorElement> _elements list of elements to use
     * @var IOperatorElementFactory _operatorElementFactory factory object that creates other objects, here, IOperatorElement
     */

    protected List<IOperatorElement> _elements = new List<IOperatorElement>();
    protected IOperatorElementFactory<IOperatorElement> _operatorElementFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param IOperatorElementFactory operatorElementFactory factory object that creates other objects, here, IOperatorElement
     */

    protected AbstractOperator(IOperatorElementFactory<IOperatorElement> operatorElementFactory)
    {
        _operatorElementFactory = operatorElementFactory;
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** ELEMENTS GETTER/SETTER *****/
    /**********************************/

    /**
     * @access public
     */

    public List<IOperatorElement> Elements
    {
        get { return _elements; }
        set { _elements = value; }
    }

    /**************************************************/
    /**************************************************/

    /**************************************************/
    /***** OPERATOR ELEMENT FACTORY GETTER/SETTER *****/
    /**************************************************/

    /**
     * @access public
     */

    public IOperatorElementFactory<IOperatorElement> OperatorElementFactory
    {
        get { return _operatorElementFactory; }
        set { _operatorElementFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** IOPERATOR INIT *****/
    /**************************/

    /**
     * @access public
     */

    public abstract void Init();

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** IOPERATOR ADD ELEMENT *****/
    /*********************************/

    /**
     * @access public
     * @param IOperatorElement element element to add
     */

    public void AddElement(IOperatorElement element)
    {
        _elements.Add(element);
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** IOPERATOR REMOVE ELEMENT *****/
    /************************************/

    /**
     * @access public
     * @param IOperatorElement element element to remove
     */

    public void RemoveElement(IOperatorElement element)
    {
        _elements.Remove(element);
    }

    /**************************************************/
    /**************************************************/

    /*****************************/
    /***** IOPERATOR OPERATE *****/
    /*****************************/

    /**
     * @access public
     */

    public abstract void Operate();
}
