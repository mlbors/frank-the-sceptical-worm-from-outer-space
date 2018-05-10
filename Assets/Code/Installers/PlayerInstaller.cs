/**
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
        // GameObject gameObject = Container.InstantiatePrefabResource("Prefabs/Player");
        Container.Bind<IPlayerStateFactory<IState>>()
                 .To<PlayerStateFactory>()
                 .AsSingle()
                 .WithArguments(_settings.playerGameObject)
                 .WhenInjectedInto<PlayerFactory>();
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