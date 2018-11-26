/**
 * FTSWFOS - AbstractDestroyerComposite - Abstract Class
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
/***** ABSTRACT DESTROYER COMPOSITE *****/
/****************************************/

abstract public class AbstractDestroyerComposite<T> : AbstractDestroyer<T>, IDestroyerComposite<T> ,IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IOperatorElement> _operatorsElement list of operators to generate various components
     */

    protected List<IOperatorElement> _operatorElements = new List<IOperatorElement>();

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     */

    protected AbstractDestroyerComposite() : base()
    {
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
