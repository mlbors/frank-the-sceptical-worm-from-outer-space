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

public class ScoreOperatorElement : IOperatorElement, IObserver
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IScore _score score object
     * @var IScoreFactory scoreFactory factory object that creates other objects, here, IScore
     */

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

    /********************************/
    /***** score GETTER/SETTER *****/
    /********************************/

    /**
     * @access public
     */

    public IScore Score
    {
        get { return _score; }
        set { _score = value; }
    }

    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    public void Init()
    {
        _score = _scoreFactory.Create();
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
                    _score.IncreaseScore((int)data);
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
            Debug.Log($"Exception thrown: {e.Message}");
            Debug.Log($"Exception thrown: {e.StackTrace}");
        }
    }
}