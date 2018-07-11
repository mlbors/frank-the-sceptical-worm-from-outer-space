/**
 * FTSWFOS - AbstractManager - Abstract Class
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

/****************************/
/***** ABSTRACT MANAGER *****/
/****************************/

abstract public class AbstractManager : IManager, IGameManager, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IOperatorFactory operatorFactory factory object that creates other objects, here, IOperator
     * @var List<IOperator> _operators list of operators to generate various components
     */

    protected IOperatorFactory<IOperator> _operatorFactory;
    protected List<IOperator> _operators = new List<IOperator>();

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param IOperatorFactory operatorFactory factory object that creates other objects, here, IOperator
     */

    protected AbstractManager(IOperatorFactory<IOperator> operatorFactory)
    {
        _operatorFactory = operatorFactory;
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

    /******************************************/
    /***** OPERATOR FACTORY GETTER/SETTER *****/
    /******************************************/

    /**
     * @access public
     */

    public IOperatorFactory<IOperator> OperatorFactory
    {
        get { return _operatorFactory; }
        set { _operatorFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** IGAME MANAGER ADD OPERATOR *****/
    /**************************************/

    /**
     * @access public
     * @param IOperator theOperator operator to add
     */

    public void AddOperator(IOperator theOperator)
    {
        Debug.Log("::: Adding operator :::");
        Debug.Log(theOperator);
        _operators.Add(theOperator);
    }

    /**************************************************/
    /**************************************************/

    /*****************************************/
    /***** IGAME MANAGER REMOVE OPERATOR *****/
    /*****************************************/

    /**
     * @access public
     * @param IOperator theOperator operator to remove
     */

    public void RemoveOperator(IOperator theOperator)
    {
        _operators.Remove(theOperator);
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** IMANAGER INIT *****/
    /*************************/

    /**
     * @access public
     */

    public abstract void Init();
}
