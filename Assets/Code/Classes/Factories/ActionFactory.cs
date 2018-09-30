/**
 * FTSWFOS - ActionFactory - Concrete Class
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

/**************************/
/***** ACTION FACTORY *****/
/**************************/

public class ActionFactory : AbstractDIFactory<IAction>, IActionFactory<IAction>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ActionType _type type of command
     */

    protected ActionType _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param ActionType type type of command
     */

    public ActionFactory(DiContainer container, ActionType type = ActionType.None) : base (container)
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

    public ActionType Type
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
     * @return IAction
     */

    public override IAction Create(params object[] constructorArguments)
    {
        IAction action;

        switch (_type)
        {
            case ActionType.Run:
                action = _container.Instantiate<RunAction>() as IAction;
                break;
            case ActionType.Jump:
                action = _container.Instantiate<JumpAction>() as IAction;
                break;
            case ActionType.DoubleJump:
                action = _container.Instantiate<DoubleJumpAction>() as IAction;
                break;
            default:
                action = _container.Instantiate<JumpAction>() as IAction;
                break;
        }

        return action;
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
        _container.Instantiate<JumpAction>();
        _container.Instantiate<DoubleJumpAction>();
        _container.Instantiate<RunAction>();
    }
}