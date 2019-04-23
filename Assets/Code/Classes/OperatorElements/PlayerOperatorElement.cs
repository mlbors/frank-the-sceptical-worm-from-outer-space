/**
 * FTSWFOS - PlayerOperatorElement - Concrete Class
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

/***********************************/
/***** PLAYER OPERATOR ELEMENT *****/
/***********************************/

public class PlayerOperatorElement : IPlayerOperatorElement, IObservable
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IObserver> _observers list of observers
     * @var IPlayer _player player object
     * @var IPlayerFactory playerFactory factory object that creates other objects, here, IPlayer
     */

    protected List<IObserver> _observers = new List<IObserver>();
    protected IPlayer _player;
    protected IPlayerFactory<IPlayer> _playerFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IPlayerFactory playerFactory factory object that creates other objects, here, IPlayer
     */

    public PlayerOperatorElement(IPlayerFactory<IPlayer> playerFactory)
    {
        _SetValues(playerFactory);
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    /**
     * @access protected
     * @param IPlayerFactory playerFactory factory object that creates other objects, here, IPlayer
     */

    protected void _SetValues(IPlayerFactory<IPlayer> playerFactory)
    {
        PlayerFactory = playerFactory;
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** PLAYER FACTORY GETTER/SETTER *****/
    /****************************************/

    /**
     * @access public
     */

    public IPlayerFactory<IPlayer> PlayerFactory
    {
        get { return _playerFactory; }
        set { _playerFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** PLAYER GETTER/SETTER *****/
    /********************************/

    /**
     * @access public
     */

    public IPlayer Player
    {
        get { return _player; }
        set { _player = value; }
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
        try
        {
            Player = _playerFactory.Create();

            if (Player != null)
            {
                Notify(ObservableEventType.PlayerCreated, Player);
            }
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
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