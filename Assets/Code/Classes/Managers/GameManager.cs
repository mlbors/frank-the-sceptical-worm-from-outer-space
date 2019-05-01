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

public class GameManager : AbstractManager, IGameManager, IObservable, IObserver
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
     * @param IOperatorFactory operatorFactory factory object that creates other objects, here, IOperator
     */

    public GameManager(IOperatorFactory<IOperator> operatorFactory) : base (operatorFactory)
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
        _operatorFactory.Type = OperatorType.GameOperator;
        IOperator gameOperator = _operatorFactory.Create();
        (gameOperator as IObservable).Attach(this as IObserver);
        Attach(gameOperator as IObserver);
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
                case ObservableEventType.SpikeHitten:
                    _StopGame();
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

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** STOP GAME *****/
    /*********************/

    /**
     * @access protected
     */

    protected void _StopGame()
    {
        Logger.LogMessage("Game would stop!");
        Notify(ObservableEventType.Death, null);
    }

}
