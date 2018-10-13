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
                 .AsCached()
                 .WhenInjectedInto<IGameOperator>()
                 .NonLazy();

        Container.Bind<IOperatorElementFactory<IOperatorElement>>()
                 .To<OperatorElementFactory>()
                 .AsCached()
                 .WhenInjectedInto<IPlatformGenerator>()
                 .NonLazy();

        Container.Bind<IGeneratorFactory<IGenerator>>()
                 .To<GeneratorFactory>()
                 .AsCached()
                 .WhenInjectedInto<IGeneratorOperatorElement>()
                 .NonLazy();

        Container.Bind<IDestroyerFactory<IDestroyer>>()
                 .To<DestroyerFactory>()
                 .AsCached()
                 .WhenInjectedInto<IGeneratorOperatorElement>()
                 .NonLazy();

        Container.Bind<IGeneratorFactory<IGenerator>>()
                 .To<GeneratorFactory>()
                 .AsCached()
                 .WhenInjectedInto<IGeneratorComponentOperatorElement>()
                 .NonLazy();

        Container.Bind<IDestroyerFactory<IDestroyer>>()
                 .To<DestroyerFactory>()
                 .AsCached()
                 .WhenInjectedInto<IGeneratorComponentOperatorElement>()
                 .NonLazy();

        Container.Bind<IPoolFactory<IPool>>()
                 .To<PoolFactory>()
                 .AsCached()
                 .WhenInjectedInto<IGenerator>()
                 .NonLazy();

        Container.Bind<List<GameObject>>()
                 .FromInstance(new List<GameObject>{ _settings.objectsGenerationPoint, _settings.objectsDestructionPoint})
                 .AsCached()
                 .WhenInjectedInto<IGeneratorOperatorElement>();

        Container.Bind<GameObject>()
                 .FromInstance(_settings.cameraGameObject)
                 .AsCached()
                 .WhenInjectedInto<CameraFactory>();

        Container.Bind<ICameraFactory<ICamera>>()
                 .To<CameraFactory>()
                 .AsSingle()
                 .WhenInjectedInto<CameraOperatorElement>()
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
         * @var GameObject cameraGameObject prefab to use for player
         * @var GameObject objectGenerationPoint point from where to generate objects
         * @var GameObject objectDestructionPoint point from where to destroy objects
         */

        public GameObject cameraGameObject;
        public GameObject objectsGenerationPoint;
        public GameObject objectsDestructionPoint;
    }
}