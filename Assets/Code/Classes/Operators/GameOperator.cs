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
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        _operatorElementFactory.Type = OperatorElementType.PlatformOperatorElement;
        IOperatorElement platformOperatorElement = _operatorElementFactory.Create();
        AddElement(platformOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.EnvironmentOperatorElement;
        IOperatorElement environmentOperatorElement = _operatorElementFactory.Create();
        AddElement(environmentOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.CameraOperatorElement;
        IOperatorElement cameraOperatorElement = _operatorElementFactory.Create();
        (cameraOperatorElement as IObservable).Attach(platformOperatorElement as IObserver);
        (cameraOperatorElement as IObservable).Attach(environmentOperatorElement as IObserver);
        AddElement(cameraOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.MenuOperatorElement;
        AddElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementType.ScoreOperatorElement;
        IOperatorElement scoreOperatorElement = _operatorElementFactory.Create();
        AddElement(scoreOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.PlayerOperatorElement;
        IOperatorElement playerOperator = _operatorElementFactory.Create();
        (playerOperator as IObservable).Attach(cameraOperatorElement as IObserver);
        (playerOperator as IObservable).Attach(scoreOperatorElement as IObserver);
        AddElement(playerOperator);
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
        try 
        {
            _SetValues();
            _InitOperators();
        }
        catch (Exception e)
        {
            Debug.Log($"Exception thrown: {e.Message}");
        }
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
        foreach (IOperatorElement element in _elements)
        {
            try 
            {
                element.Init();
            }
            catch(Exception e)
            {
                Debug.Log($"Exception thrown: {e.Message}");
            }
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
        foreach (IOperatorElement element in _elements)
        {
            try
            {
                element.Operate();
            }
            catch (Exception e)
            {
                Debug.Log($"Exception thrown: {e.Message}");
            }
        }
    }
}
