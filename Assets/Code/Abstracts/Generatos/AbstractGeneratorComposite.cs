/**
 * FTSWFOS - AbstractGeneratorComposite - Abstract Class
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

/****************************************/
/***** ABSTRACT GENERATOR COMPOSITE *****/
/****************************************/

abstract public class AbstractGeneratorComposite<T> : AbstractGenerator<T>, IGeneratorComposite<T> ,IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var GameObject _gameObject player's game object
     * @var List<IOperator> _operators list of operators to generate various components
     */

    protected GameObject _gameObject;
    protected List<IOperator> _operators = new List<IOperator>();

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
}
