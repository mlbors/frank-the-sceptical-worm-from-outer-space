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

public class PlayerFactory : AbstractDIFactory<IPlayer>, IPlayerFactory<IPlayer>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var GameObject _gameObject player's game object
     * @var IPlayerStateFactory _stateFactory object that create other objects, here, IState
     */

    protected GameObject _gameObject;
    protected IPlayerStateFactory<IPlayerState> _stateFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @var GameObject _gameObject player's game object
     * @param IPlayerStateFactory stateFactory object that create other objects, here, IState
     */

    public PlayerFactory(DiContainer container, GameObject gameObject, IPlayerStateFactory<IPlayerState> stateFactory) : base (container)
    {
        Debug.Log("::: Player Factory :::");
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

    public IPlayerStateFactory<IPlayerState> StateFactory
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
        Debug.Log("::: Creating Player :::");
        IPlayer player;
        _container.Bind<IPlayer>().To<Player>().AsSingle();
        var prefab = _container.InstantiatePrefab(_gameObject);
        player = _container.InstantiateComponent<Player>(prefab);
        player.StateFactory = _stateFactory;
        player.StateFactory.Subject = player as IPlayerStateSubject;
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
        //_container.Instantiate<Player>();
    }
}