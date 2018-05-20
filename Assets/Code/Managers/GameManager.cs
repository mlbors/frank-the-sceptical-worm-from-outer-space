/**
 * FTSWFOS - GameManager - Abstract Class
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

/**************************************************/
/**************************************************/

/************************/
/***** GAME MANAGER *****/
/************************/

public class GameManager : AbstractManager, IGameManager
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IOperator> _operators list of operators to use
     */

    protected List<IOperator> _operators;

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

    /*************************/
    /***** IMANAGER INIT *****/
    /*************************/

    /**
     * @access public
     */

    public override void Init()
    {
        foreach (IOperator o in _operators)
        {
            o.Init();
        }
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

}
