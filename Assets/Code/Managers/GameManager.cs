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
using Zenject;

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

    [Inject]
    public override void Construct(IOperatorFactory<IOperator> operatorFactory)
    {
        base.Construct(operatorFactory);
        _SetValues();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    void _SetValues()
    {
        _operatorFactory.Type = OperatorTypes.GameOperator;
        IOperator gameOperator = _operatorFactory.Create();
        Console.WriteLine("::: GameOperator Object :::");
        Console.WriteLine(gameOperator);
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
        Console.WriteLine("::: GameManager Init :::");
        foreach (IOperator o in _operators)
        {
            o.Init();
        }
    }
}
