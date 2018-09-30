/**
 * FTSWFOS - PlayerInputHandlerFactory - Concrete Class
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

/****************************************/
/***** PALYER INPUT HANDLER FACTORY *****/
/****************************************/

public class PlayerInputHandlerFactory : AbstractDIFactory<IStateInputHandler>, IPlayerInputHandlerFactory<IStateInputHandler>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var PlayerInputHandlerType _type type of state
     */

    protected PlayerInputHandlerType _type;

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** TYPES GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public PlayerInputHandlerType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param PlayerState type type of state
     */

    public PlayerInputHandlerFactory(DiContainer container, PlayerInputHandlerType type = PlayerInputHandlerType.Standing) : base (container)
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
     * @return IStateInputHandler
     */

    public override IStateInputHandler Create(params object[] constructorArguments)
    {
        IStateInputHandler stateInputHandler;

        switch (_type)
        {
            case PlayerInputHandlerType.Standing:
                stateInputHandler = _container.Instantiate<StandingPlayerStateInputHandler>(new object[] { });
                break;
            case PlayerInputHandlerType.Running:
                stateInputHandler = _container.Instantiate<RunningPlayerStateInputHandler>(new object[] { });
                break;
            default:
                stateInputHandler = _container.Instantiate<StandingPlayerStateInputHandler>(new object[] { });
                break;
        }

        return stateInputHandler;
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
        _container.Instantiate<StandingPlayerStateInputHandler>();
    }
}