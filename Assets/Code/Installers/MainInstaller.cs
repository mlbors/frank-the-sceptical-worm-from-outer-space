/**
 * FTSWFOS - MainInstaller - Concrete Class
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

/**************************/
/***** MAIN INSTALLER *****/
/**************************/

public class MainInstaller : MonoInstaller
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Settings _settings Platforms Installer settings
     */

    [SerializeField]
    Settings _settings;

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** INSTALL BINDINGS *****/
    /****************************/

    public override void InstallBindings()
    {
        Debug.Log("::: Install main bindings :::");
        Container.Bind<IGameLoader>()
                 .To<GameLoader>()
                 .FromNewComponentOnNewGameObject()
                 .WithGameObjectName("MainLoader")
                 .AsSingle()
                 .NonLazy();
        
        Container.Bind<IManagerFactory<IManager>>()
                 .To<ManagerFactory>()
                 .AsSingle()
                 .WhenInjectedInto<IGameLoader>()
                 .NonLazy();

        Container.Bind<IOperatorFactory<IOperator>>()
                 .To<OperatorFactory>()
                 .AsSingle()
                 .WhenInjectedInto<IGameManager>()
                 .NonLazy();

        Container.Bind<IOperatorElementFactory<IOperatorElement>>()
                 .To<OperatorElementFactory>()
                 .AsSingle()
                 .WhenInjectedInto<IGameOperator>()
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
    }
}