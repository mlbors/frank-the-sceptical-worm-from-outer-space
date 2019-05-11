/**
 * FTSWFOS - MenuInstaller - Concrete Class
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
using UnityEngine.UI;

using Zenject;

/**************************************************/
/**************************************************/

/**************************/
/***** MENU INSTALLER *****/
/**************************/

public class MenuInstaller : MonoInstaller
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Settings _settings Score Installer settings
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
                 .FromInstance(_settings.menus)
                 .WhenInjectedInto<MenuFactory>();

        Container.Bind<GameObject>()
                 .FromInstance(_settings.mainCanvas)
                 .WhenInjectedInto<MenuFactory>();

        Container.Bind<IMenuFactory<IMenu>>()
                 .To<MenuFactory>()
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
         * @var List<GameObject> menus list of menus
         * @var GameObject mainCanvas main canvas to render UI components        
         */

        public List<GameObject> menus;
        public GameObject mainCanvas;
    }
}