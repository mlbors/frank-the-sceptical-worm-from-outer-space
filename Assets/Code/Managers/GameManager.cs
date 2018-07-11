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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************/
/**************************************************/

/************************/
/***** GAME MANAGER *****/
/************************/

public class GameManager : AbstractManager, IGameManager
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IOperatorFactory operatorFactory factory object that creates other objects, here, IOperator
     */

    public GameManager(IOperatorFactory<IOperator> operatorFactory) : base (operatorFactory)
    {
        Debug.Log("::: GameManager construct :::");
        _SetValues();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        Debug.Log("::: GameManager setting values :::");
        _operatorFactory.Type = OperatorTypes.GameOperator;
        IOperator gameOperator = _operatorFactory.Create();
        Debug.Log("::: GameOperator Object :::");
        Debug.Log(gameOperator);
        AddOperator(gameOperator);
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
        Debug.Log("::: GameManager Init Class :::");
        Debug.Log("::: Try to init operators :::");
        foreach (IOperator o in _operators)
        {
            o.Init();
        }
    }
}
