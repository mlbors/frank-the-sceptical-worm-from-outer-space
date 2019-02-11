/**
 * FTSWFOS - EnvironmentInstaller - Concrete Class
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

/*********************************/
/***** ENVIRONMENT INSTALLER *****/
/*********************************/

public class EnvironmentInstaller : MonoInstaller
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

    /**
     * @access public
     */

    public override void InstallBindings()
    {
        Container.Bind<List<GameObject>>()
                 .FromInstance(_settings.environmentObjects)
                 .WhenInjectedInto<EnvironmentObjectFactory>();

        Container.Bind<IEnvironmentObjectFactory<IEnvironmentObject>>()
                 .To<EnvironmentObjectFactory>()
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
         * @var List<GameObject> environmentObjects list of environment objects
         */

        public List<GameObject> environmentObjects;
    }
}