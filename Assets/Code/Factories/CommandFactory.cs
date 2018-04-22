/**
 * FTSWFOS - CommandFactory - Concrete Class
 *
 * @since       09.01.2018
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/**************************************************/
/**************************************************/

/***************************/
/***** COMMAND FACTORY *****/
/***************************/

public class CommandFactory : AbstractDIFactory
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var String _type type of command
     */

    protected string _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @param DiContainer container DI container
     * @param String type type of command
     */

    public CommandFactory(DiContainer container, string type) : base (container)
    {
        _type = type;
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return ICommand 
     */

    public override ICommand Create<ICommand, IProduct>(params object[] constructorArguments)
    {
        var command = _container.Instantiate<JumpCommand>();
        return command as ICommand;
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** IVALIDATABLE VALIDATABLE *****/
    /************************************/

    /**
     * @access public
     */

    public override void Validate()
    {
        _container.Instantiate<JumpCommand>();
    }
}