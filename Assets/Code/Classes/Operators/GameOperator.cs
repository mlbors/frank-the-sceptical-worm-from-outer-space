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

public class GameOperator : AbstractOperator, IGameOperator, IObservable, IObserver
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IObserver> _observers list of observers
     */

    protected List<IObserver> _observers = new List<IObserver>();

    /**************************************************/
    /**************************************************/

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

    /***********************************/
    /***** OBSERVERS GETTER/SETTER *****/
    /***********************************/

    /**
     * @access public
     */

    public List<IObserver> Observers
    {
        get { return _observers; }
        set { _observers = value; }
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
        Attach(platformOperatorElement as IObserver);
        AddElement(platformOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.ScoreOperatorElement;
        IOperatorElement scoreOperatorElement = _operatorElementFactory.Create();
        (scoreOperatorElement as IObservable).Attach(platformOperatorElement as IObserver);
        Attach(scoreOperatorElement as IObserver);
        AddElement(scoreOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.EnvironmentOperatorElement;
        IOperatorElement environmentOperatorElement = _operatorElementFactory.Create();
        AddElement(environmentOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.DeathBoxOperatorElement;
        IOperatorElement deathBoxOperatorElement = _operatorElementFactory.Create();
        Attach(deathBoxOperatorElement as IObserver);
        AddElement(deathBoxOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.CameraOperatorElement;
        IOperatorElement cameraOperatorElement = _operatorElementFactory.Create();
        (cameraOperatorElement as IObservable).Attach(platformOperatorElement as IObserver);
        (cameraOperatorElement as IObservable).Attach(environmentOperatorElement as IObserver);
        Attach(cameraOperatorElement as IObserver);
        AddElement(cameraOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.MenuOperatorElement;
        IOperatorElement menuOperatorElement = _operatorElementFactory.Create();
        Attach(menuOperatorElement as IObserver);
        AddElement(menuOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.PlayerOperatorElement;
        IOperatorElement playerOperator = _operatorElementFactory.Create();
        (playerOperator as IObservable).Attach(cameraOperatorElement as IObserver);
        (playerOperator as IObservable).Attach(deathBoxOperatorElement as IObserver);
        (playerOperator as IObservable).Attach(scoreOperatorElement as IObserver);
        Attach(playerOperator as IObserver);
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
            Notify(ObservableEventType.GameInitialized, this);
        }
        catch (Exception e)
        {
            Logger.LogException(e);
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
                Logger.LogException(e);
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
                Logger.LogException(e);
            }
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     */

    public void ObserverUpdate(ObservableEventType info, object data)
    {
        try
        {
            switch (info)
            {
                case ObservableEventType.Death:
                    Notify(ObservableEventType.Death, null);
                    break;

                case ObservableEventType.GameRestarts:
                    Notify(ObservableEventType.GameRestarts, null);
                    break;

                case ObservableEventType.RestartButtonClicked:
                    Notify(ObservableEventType.RestartButtonClicked, null);
                    break;

                case ObservableEventType.SpikeHitten:
                    Notify(ObservableEventType.PlayerIsDead, data);
                    break;

                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IOBSERVABLE - ATTACH *****/
    /********************************/

    /**
     * @access private
     * @param IObserver observer observer to attach
     */

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IOBSERVABLE - DETACH *****/
    /********************************/

    /**
     * @access private
     * @param IObserver observer observer to detach
     */

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** IOBSERVABLE NOTIFY *****/
    /******************************/

    /**
     * @access private
     * @param String info info for update
     */

    public void Notify(ObservableEventType info, object data)
    {
        foreach (IObserver o in _observers)
        {
            o.ObserverUpdate(info, data);
        }
    }
}
