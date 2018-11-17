/**
 * FTSWFOS - CollectablesInstaller - Concrete Class
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

/**********************************/
/***** COLLECTABLES INSTALLER *****/
/**********************************/

public class CollectablesInstaller : MonoInstaller
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Settings _settings Collectables Installer settings
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
        Container.Bind<List<GameObject>>()
                 .FromInstance(_settings.collectables)
                 .WhenInjectedInto<CollectableFactory>();

        Container.Bind<ICollectableFactory<ICollectable>>()
                 .To<CollectableFactory>()
                 .AsSingle();
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
         * @var List<GameObject> collectables list of collectables
         */

        public List<GameObject> collectables;
    }
}