/**
 * FTSWFOS - PlayerFactory - Concrete Class
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

/**************************/
/***** PLAYER FACTORY *****/
/**************************/

public class PlayerFactory : AbstractDIFactory<IPlayer>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var GameObject _gameObject player's game object
     * @var IFactory _stateFactory object that create other objects, here, IState
     */

    protected GameObject _gameObject;
    protected IFactory _stateFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @var GameObject _gameObject player's game object
     * @param IFactory stateFactory object that create other objects, here, IState
     */

    public PlayerFactory(DiContainer container, GameObject gameObject, IFactory stateFactory) : base (container)
    {
        _gameObject = gameObject;
        _stateFactory = stateFactory;
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** GAME OBJECT GETTER/SETTER *****/
    /*************************************/

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

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return IPlayer
     */

    public override IPlayer Create(params object[] constructorArguments)
    {
        IPlayer player;
        player = _container.Instantiate<Player>(new object[] { _gameObject, _stateFactory }) as IPlayer;
        return player;
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** IVALIDATABLE VALIDATABLE *****/
    /************************************/

    /**
     * @access public
     */

    public override void Validate()
    {
        _container.Instantiate<Player>();
    }
}