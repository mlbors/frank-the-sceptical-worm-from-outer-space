/**
 * FTSWFOS - ScoreOperatorElement - Concrete Class
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

/**********************************/
/***** SCORE OPERATOR ELEMENT *****/
/**********************************/

public class ScoreOperatorElement : IOperatorElement, IObserver, IObservable
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IObserver> _observers list of observers
     * @var IScore _score score object
     * @var IScoreFactory scoreFactory factory object that creates other objects, here, IScore
     */

    protected List<IObserver> _observers = new List<IObserver>();
    protected IScore _score;
    protected IScoreFactory<IScore> _scoreFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    public ScoreOperatorElement(IScoreFactory<IScore> scoreFactory)
    {
        _SetValues(scoreFactory);
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    /**
     * @access protected
     * @param IScoreFactory scoreFactory factory object that creates other objects, here, IScore
     */

    protected void _SetValues(IScoreFactory<IScore> scoreFactory)
    {
        ScoreFactory = scoreFactory;
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** SCORE FACTORY GETTER/SETTER *****/
    /***************************************/

    /**
     * @access public
     */

    public IScoreFactory<IScore> ScoreFactory
    {
        get { return _scoreFactory; }
        set { _scoreFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** SCORE GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public IScore Score
    {
        get { return _score; }
        set { _score = value; }
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

    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    public void Init()
    {
        _score = _scoreFactory.Create();
        Notify(ObservableEventType.ScoreInitialized, this);
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** OPERATORELEMENT - OPERATE *****/
    /*************************************/

    public void Operate()
    {
        
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
                case ObservableEventType.BonusHitten:
                case ObservableEventType.PlayerIsAlive:
                case ObservableEventType.SpikeHitten:
                    _score.IncreaseScore((int)data);
                    break;
                case ObservableEventType.GameRestarts:
                    _score.ResetScore();
                    break;
                case ObservableEventType.PlayerCreated:
                    (data as IObservable).Attach(this as IObserver);
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