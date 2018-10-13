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
     * @var List<IOperatorElement> _operatorsElement list of operators to generate various components
     * @var IOperatorElementFactory<IOperatorElement> _operatorElementFactory object that create other objects, here, IOperatorElementFactory
     */

    protected List<IOperatorElement> _operatorElements = new List<IOperatorElement>();
    protected IOperatorElementFactory<IOperatorElement> _operatorElementFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param IOperatorElementFactory<IOperatorElement> operatorElementFactory object that create other objects, here, IOperatorElementFactory
     * @param IPoolFactory _poolFactory factory object that creates other objects, here, IPool
     */

    protected AbstractGeneratorComposite(IOperatorElementFactory<IOperatorElement> operatorElementFactory,
                                         IPoolFactory<IPool> poolFactory) : base(poolFactory)
    {
        OperatorElementFactory = operatorElementFactory;
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** OPERATOR ELEMENTS GETTER/SETTER *****/
    /*******************************************/

    /**
     * @access public
     */

    public List<IOperatorElement> OperatorElements
    {
        get { return _operatorElements; }
        set { _operatorElements = value; }
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

    /******************************************/
    /***** IPLATFORM ADD OPERATOR ELEMENT *****/
    /******************************************/

    /**
     * @access public
     * @param IOperatorElement operatorElement opertorElement to add
     */

    public void AddOperatorElement(IOperatorElement operatorElement)
    {
        _operatorElements.Add(operatorElement);
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** IPLATFORM REMOVE OPERATOR *****/
    /*************************************/

    /**
     * @access public
     * @param IOperatorElement operatorElement opertorElement to remove
     */

    public void RemoveOperatorElement(IOperatorElement operatorElement)
    {
        _operatorElements.Remove(operatorElement);
    }

    /**************************************************/
    /**************************************************/

    /***********************************************/
    /***** IPLATFORM EXECUTE OPERATOR ELEMENTS *****/
    /***********************************************/

    /**
     * @access public
     */

    public abstract void ExecuteOperatorElements();
}
