/**
 * FTSWFOS - AbstractOperator - Abstract Class
 *
 * @since       09.01.2018
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

abstract public class AbstractOperator : IOperator
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IOperatorElement> _elements list of elements to use
     */

    protected List<IOperatorElement> _elements;

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** ELEMENTS GETTER/SETTER *****/
    /**********************************/

    /*
     * @access public
     */

    public List<IOperatorElement> Elements
    {
        get { return _elements; }
        set { _elements = value; }
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
