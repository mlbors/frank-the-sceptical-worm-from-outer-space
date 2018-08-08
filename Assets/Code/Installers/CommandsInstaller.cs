/**
 * FTSWFOS - CommandsInstaller - Concrete Class
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

/******************************/
/***** COMMANDS INSTALLER *****/
/******************************/

public class CommandsInstaller : MonoInstaller
{
    /****************************/
    /***** INSTALL BINDINGS *****/
    /****************************/

    /**
     * @access public
     */

    public override void InstallBindings()
    {
        
        Container.Bind<IActionFactory<IAction>>()
                 .To<ActionFactory>()
                 .AsSingle()
                 .WhenInjectedInto<ICommand>()
                 .NonLazy();
    }
}