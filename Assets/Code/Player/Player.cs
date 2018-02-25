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
     * @var IFactory _commandfactory object that creates commands
     */

    private IPlayerState _state;
    private List<IObserver> _observers = new List<IObserver>();
    private IInvoker _inputHandler;
    private IFactory<ICommand, IProduct> _commandFactory;

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** STATE GETTER/SETTER *****/
    /*******************************/

    /*
     * @access public
     */

    public IPlayerState State
    {
        get { return _state; }
        set { _state = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** INPUT HANDLER GETTER/SETTER *****/
    /***************************************/

    /*
     * @access public
     */

    public IInvoker InputHandler
    {
        get { return _inputHandler; }
        set { _inputHandler = value; }
    }

    /**************************************************/
    /**************************************************/

    /*****************************************/
    /***** COMMAND FACTORY GETTER/SETTER *****/
    /*****************************************/

    /*
     * @access public
     */

    public IFactory<ICommand, IProduct> CommandFactory
    {
        get { return _commandFactory; }
        set { _commandFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access private
     */

    void Start()
    {

    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /**
     * @access private
     */

    void Update()
    {
        
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

    /********************************/
    /***** IOBSERVABLE - NOTIFY *****/
    /********************************/

    /**
     * @access private
     */

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

    /**
     * @access private
     */

    void IWithState.UpdateState()
    {
        
    }

    /**************************************************/
    /**************************************************/

    /************************/
    /***** HANDLE INPUT *****/
    /************************/

    /**
     * @access private
     */

    void HandleInput()
    {
        ICommand command = _commandFactory.Create();
        _inputHandler.SetCommand(command);
        _inputHandler.ExecuteCommand();
    }
}