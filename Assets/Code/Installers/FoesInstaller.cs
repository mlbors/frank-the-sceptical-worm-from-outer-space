/**
 * FTSWFOS - FoesInstaller - Concrete Class
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
/***** FOES INSTALLER *****/
/**************************/

public class FoesInstaller : MonoInstaller
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Settings _settings Foes Installer settings
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
                 .FromInstance(_settings.foes)
                 .WhenInjectedInto<FoeFactory>();

        Container.Bind<IFoeFactory<IFoe>>()
                 .To<FoeFactory>()
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
         * @var List<GameObject> foes list of foes
         */

        public List<GameObject> foes;
    }
}