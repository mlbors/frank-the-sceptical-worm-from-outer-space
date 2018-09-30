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

public class CommandFactory : AbstractDIFactory<ICommand>, ICommandFactory<ICommand>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var CommandType _type type of command
     */

    protected CommandType _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param CommandType type type of command
     */

    public CommandFactory(DiContainer container, CommandType type = CommandType.None) : base (container)
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

    public CommandType Type
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
            case CommandType.Run:
                command = _container.Instantiate<RunCommand>() as ICommand;
                break;
            case CommandType.Jump:
                command = _container.Instantiate<JumpCommand>() as ICommand;
                break;
            case CommandType.DoubleJump:
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
        _container.Instantiate<RunCommand>();
    }
}