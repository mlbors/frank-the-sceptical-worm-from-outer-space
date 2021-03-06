﻿/**
 * FTSWFOS - ScoreInstaller - Concrete Class
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

/***************************/
/***** SCORE INSTALLER *****/
/***************************/

public class ScoreInstaller : MonoInstaller
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