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
        _InstallLoaders();
        _InstallManagers();
        _InstallOperators();
        _InstallGeneratorsAndDestroyers();
        _InstallCollectables();
        _InstallFoes();
        _InstallCamera();
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** INSTALL LOADERS *****/
    /***************************/

    /**
     * @access protected
     */

    protected void _InstallLoaders()
    {
        Container.Bind<IGameLoader>()
                 .To<GameLoader>()
                 .FromNewComponentOnNewGameObject()
                 .WithGameObjectName("MainLoader")
                 .AsSingle()
                 .NonLazy();
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** INSTALL MANAGERS *****/
    /****************************/

    /**
     * @access protected
     */

    protected void _InstallManagers()
    {
        Container.Bind<IManagerFactory<IManager>>()
                 .To<ManagerFactory>()
                 .AsSingle()
                 .WhenInjectedInto<IGameLoader>()
                 .NonLazy();
    }

    /**************************************************/
    /**************************************************/

    /*****************************/
    /***** INSTALL OPERATORS *****/
    /*****************************/

    /**
     * @access protected
     */

    protected void _InstallOperators()
    {
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
                 .WhenInjectedInto<IGeneratorOperatorElement>()
                 .NonLazy();
    }

    /**************************************************/
    /**************************************************/

    /********************************************/
    /***** INSTALL GENRATORS AND DESTROYERS *****/
    /********************************************/

    /**
     * @access protected
     */

    protected void _InstallGeneratorsAndDestroyers()
    {
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

        Container.Bind<IPoolFactory<IPool>>()
                 .To<PoolFactory>()
                 .AsCached()
                 .WhenInjectedInto<IGeneratorOperatorElement>()
                 .NonLazy();

        Container.Bind<IObjectComputerFactory<IObjectComputer>>()
                 .To<ObjectComputerFactory>()
                 .AsCached()
                 .WhenInjectedInto<IGenerator>()
                 .NonLazy();
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** INSTALL COLLECTABLES *****/
    /********************************/

    /**
     * @access protected
     */

    protected void _InstallCollectables()
    {
        Container.Bind<ICollectableFactory<ICollectable>>()
                  .To<CollectableFactory>()
                  .AsSingle();

        Container.Bind<List<GameObject>>()
                 .FromInstance(_settings.collectables)
                 .WhenInjectedInto<CollectableFactory>();
    }

    /**************************************************/
    /**************************************************/

    /************************/
    /***** INSTALL FOES *****/
    /************************/

    /**
     * @access protected
     */

    protected void _InstallFoes()
    {
        Container.Bind<IFoeFactory<IFoe>>()
                 .To<FoeFactory>()
                 .AsSingle();

        Container.Bind<List<GameObject>>()
                 .FromInstance(_settings.foes)
                 .WhenInjectedInto<FoeFactory>();
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** INSTALL CAMERA *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _InstallCamera()
    {
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
         * @var GameObject cameraGameObject prefab to use camera
         * @var GameObject objectGenerationPoint point from where to generate objects
         * @var GameObject objectDestructionPoint point from where to destroy objects
         * @var List<GameObject> collectables list of collectables
         * @var List<GameObject> foes list of foes
         */

        public GameObject cameraGameObject;
        public GameObject objectsGenerationPoint;
        public GameObject objectsDestructionPoint;
        public List<GameObject> collectables;
        public List<GameObject> foes;
    }
}