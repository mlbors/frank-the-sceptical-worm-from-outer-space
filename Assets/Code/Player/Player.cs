/**
 * FTSWFOS - Player - Concrete Classe
 *
 * @since       09.01.2018
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

/**************************************************/
/**************************************************/

/******************/
/***** PLAYER *****/
/******************/

public class Player : MonoBehaviour, IPlayer, ICameraTarget, IObservable, IWithState
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IPlayerState _state player's state
     * @var List<IObserver> _observers list of observers
     * @var IInvoker _inputHandler manage input commands
     */

    private IPlayerState _state;
    private List<IObserver> _observers = new List<IObserver>();
    private IInvoker _inputHandler;

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** STATE GETTER/SETTER *****/
    /*******************************/

    public IPlayerState State
    {
        get { return _state; }
        set { _state = value; }
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** START *****/
    /*****************/

    void Start()
    {

    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    void Update()
    {
        
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IOBSERVABLE - ATTACH *****/
    /********************************/

    /**
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
     * @param IObserver observer observer to detach
     */

    void IObservable.Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IOBSERVABLE - NOTIFY *****/
    /********************************/

    void IObservable.Notify()
    {
        foreach (IObserver o in _observers)
        {
            //o.Update();
        }
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** IWITH STATE - UPDATE STATE *****/
    /**************************************/

    void IWithState.UpdateState()
    {
        
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** INPUTHANDLER GETTER/SETTER *****/
    /**************************************/

    public IInvoker InputHandler
    {
        get { return _inputHandler; }
        set { _inputHandler = value; }
    }

    /**************************************************/
    /**************************************************/

    /************************/
    /***** HANDLE INPUT *****/
    /************************/

    void HandleInput()
    {
        ICommand command = new JumpCommand(_state);
        _inputHandler.SetCommand(command);
        _inputHandler.ExecuteCommand();
    }
}