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
     * @var PlayerInputHandlerTypes _type type of state
     */

    protected PlayerInputHandlerTypes _type;

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** TYPES GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public PlayerInputHandlerTypes Type
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
     * @param PlayerStates type type of state
     */

    public PlayerInputHandlerFactory(DiContainer container, PlayerInputHandlerTypes type = PlayerInputHandlerTypes.Standing) : base (container)
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
            case PlayerInputHandlerTypes.Standing:
                stateInputHandler = _container.Instantiate<StandingPlayerStateInputHandler>(new object[] { });
                break;
            case PlayerInputHandlerTypes.Running:
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