﻿/**
 * FTSWFOS - AbstractPlayer - Abstract Class
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
using UnityEngine;
using Zenject;

/**************************************************/
/**************************************************/

/***************************/
/***** ABSTRACT PLAYER *****/
/***************************/

abstract public class AbstractPlayer : MonoBehaviour, ICameraTarget, IStateSubject, IObserver, IObservable, IPlayer, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var GameObject _gameObject player's game object
     * @var IState _state player's state
     * @var IPlayerStateFactory _stateFactory object that create other objects, here, IState
     * @var List<IObserver> _observers list of observers
     */

    protected GameObject _gameObject;
    protected IState _state;
    protected IPlayerStateFactory _stateFactory;
    protected List<IObserver> _observers;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param GameObject gameObject player's game object
     * @param IPlayerStateFactory stateFactory object that create other objects, here, IState
     */

    [Inject]
    public virtual void Construct(GameObject gameObject, IPlayerStateFactory stateFactory)
    {
        _gameObject = gameObject;
        _stateFactory = stateFactory;
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** GAME OBEJECT GETTER/SETTER *****/
    /**************************************/

    /**
     * @access public
     */

    public GameObject GameObject
    {
        get { return _gameObject; }
        set { _gameObject = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** STATE GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public IState State
    {
        get { return _state; }
        set { _state = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** STATE FACTORY GETTER/SETTER *****/
    /***************************************/

    /**
     * @access public
     */

    public IFactory StateFactory
    {
        get { return _stateFactory; }
        set { _stateFactory = value; }
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

    /********************************/
    /***** IOBSERVABLE - ATTACH *****/
    /********************************/

    /**
     * @access private
     * @param IObserver observer observer to attach
     */

    void IObservable.Attach(IObserver observer)
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

    void IObservable.Detach(IObserver observer)
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
     */

    void IObservable.Notify()
    {
        foreach (IObserver o in _observers)
        {
            o.ObserverUpdate();
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

    public abstract void ObserverUpdate();

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IPLAYER HANDLE INPUT *****/
    /********************************/

    /**
     * @access public
     */

    public abstract void HandleInput();

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** ISTATE SUBJECT UPDATE STATE *****/
    /***************************************/

    /**
     * @access public
     */

    public abstract void UpdateState();

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access public
     */

    public abstract void Start();

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /**
     * @access public
     */

    public abstract void Update();

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** ON COLLISION ENTER 2D *****/
    /*********************************/

    /**
     * @access public
     */
  
    public abstract void OnCollisionEnter2D(Collision2D other);
}
