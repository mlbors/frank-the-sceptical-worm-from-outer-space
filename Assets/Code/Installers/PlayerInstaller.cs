﻿/**
 * FTSWFOS - PlayerInstaller - Concrete Class
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

/****************************/
/***** PALYER INSTALLER *****/
/****************************/

public class PlayerInstaller : MonoInstaller
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Settings _settings Player Installer settings
     */

    [SerializeField]
    Settings _settings;

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** INSTALL BINDINGS *****/
    /****************************/

    /**
     * @access public
     */

    public override void InstallBindings()
    {
        Container.Bind<ICommandFactory<ICommand>>()
                 .To<CommandFactory>()
                 .AsSingle()
                 .WhenInjectedInto<IPlayerState>();
        
        Container.Bind<IPlayerInputHandlerFactory<IStateInputHandler>>()
                 .To<PlayerInputHandlerFactory>()
                 .AsSingle()
                 .WhenInjectedInto<IPlayerStateFactory<IPlayerState>>();

        Container.Bind<IPlayerStateFactory<IPlayerState>>()
                 .To<PlayerStateFactory>()
                 .AsCached()
                 .WhenInjectedInto<IPlayerFactory<IPlayer>>()
                 .NonLazy();

        Container.Bind<IPlayerStateFactory<IPlayerState>>()
                 .To<PlayerStateFactory>()
                 .AsCached()
                 .WhenInjectedInto<IPlayer>()
                 .NonLazy();

        Container.Bind<GameObject>()
                 .FromInstance(_settings.playerGameObject)
                 .AsCached()
                 .WhenInjectedInto<PlayerFactory>();

        Container.Bind<IPlayerFactory<IPlayer>>()
                 .To<PlayerFactory>()
                 .AsSingle()
                 .WhenInjectedInto<PlayerOperatorElement>()
                 .NonLazy();
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** SETTINGS *****/
    /********************/

    /**
     * @access public
     */

    [Serializable]
    public class Settings
    {
        /*********************/
        /***** ATTRIBUTS *****/
        /*********************/

        /**
         * @var GameObject playerGameObject prefab to use for player
         */

        public GameObject playerGameObject;

    }
}