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
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        _operatorFactory.Type = OperatorType.GameOperator;
        IOperator gameOperator = _operatorFactory.Create();
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
        _SetValues();

        foreach (IOperator o in _operators)
        {
            try
            {
                o.Init();
                o.Operate();
            }
            catch (Exception e)
            {
                Logger.LogException(e);
            }
        }
    }
}
