/**
 * FTSWFOS - CommandFactory - Concrete Class
 *
 * @since       2018.01.09
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

public class CommandFactory : AbstractDIFactory<ICommand>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var CommandTypes _type type of command
     */

    protected CommandTypes _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param CommandTypes type type of command
     */

    public CommandFactory(DiContainer container, CommandTypes type) : base (container)
    {
        _type = type;
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** TYPES GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public CommandTypes Type
    {
        get { return _type; }
        set { _type = value; }
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

    public override ICommand Create(params object[] constructorArguments)
    {
        ICommand command;

        switch (_type)
        {
            case CommandTypes.Jump:
                command = _container.Instantiate<JumpCommand>() as ICommand;
                break;
            case CommandTypes.DoubleJump:
                command = _container.Instantiate<DoubleJumpCommand>() as ICommand;
                break;
            default:
                command = _container.Instantiate<JumpCommand>() as ICommand;
                break;
        }

        return command;
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
        _container.Instantiate<DoubleJumpCommand>();
    }
}