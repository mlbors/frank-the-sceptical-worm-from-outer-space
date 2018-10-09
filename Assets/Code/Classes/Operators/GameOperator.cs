/**
 * FTSWFOS - GameOperator - Concrete Class
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
using Zenject;

/**************************************************/
/**************************************************/

/*************************/
/***** GAME OPERATOR *****/
/*************************/

public class GameOperator : AbstractOperator, IGameOperator
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IOperatorElementFactory operatorElementFactory factory object that creates other objects, here, IOperatorElement
     */

    public GameOperator(IOperatorElementFactory<IOperatorElement> operatorElementFactory) : base(operatorElementFactory)
    {
        Debug.Log("::: GameOperator construct :::");
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        _operatorElementFactory.Type = OperatorElementType.CameraOperatorElement;
        IOperatorElement cameraOperatorElement = _operatorElementFactory.Create();
        AddElement(cameraOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.MenuOperatorElement;
        AddElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementType.PlatformOperatorElement;
        AddElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementType.PlayerOperatorElement;
        IOperatorElement playerOperator = _operatorElementFactory.Create();
        (playerOperator as IPlayerOperatorElement).Attach(cameraOperatorElement as IObserver);
        AddElement(playerOperator);

        _operatorElementFactory.Type = OperatorElementType.ScoreOperatorElement;
        AddElement(_operatorElementFactory.Create());
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** IOPERATOR INIT *****/
    /**************************/

    /**
     * @access public
     */

    public override void Init() 
    {
        _SetValues();
        _InitOperators();
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** INIT OPERATORS *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _InitOperators()
    {
        Debug.Log("::: GameOperator Init operators :::");

        foreach (IOperatorElement element in _elements)
        {
            element.Init();
        }
    }

    /**************************************************/
    /**************************************************/

    /*****************************/
    /***** IOPERATOR OPERATE *****/
    /*****************************/

    /**
     * @access public
     */

    public override void Operate()
    {
        Debug.Log("::: GameOperator Operate :::");

        foreach (IOperatorElement element in _elements)
        {
            element.Operate();
        }
    }
}
