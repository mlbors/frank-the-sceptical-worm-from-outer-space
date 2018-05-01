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

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
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
        GameObject gameObject = Container.InstantiatePrefabResource("player");
        Container.Bind<IFactory>()
                 .To<PlayerStateFactory>()
                 .AsSingle()
                 .WithArguments(gameObject)
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
      
    }
}