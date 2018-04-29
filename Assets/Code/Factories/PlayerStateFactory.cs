﻿/**
 * FTSWFOS - PlayerStateFactory - Concrete Class
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

/********************************/
/***** PALYER STATE FACTORY *****/
/********************************/

public class PlayerStateFactory : AbstractDIFactory
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var PlayerStates _type type of state
     */

    protected PlayerStates _type;

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

    public PlayerStateFactory(DiContainer container, PlayerStates type) : base (container)
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

    public PlayerStates Type
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
     * @return IState
     */

    public override IState Create<IState, IProduct>(params object[] constructorArguments)
    {
        IState state;

        switch (_type)
        {
            case PlayerStates.Standing:
                state = _container.Instantiate<StandingPlayerState>() as IState;
                break;
            default:
                state = _container.Instantiate<StandingPlayerState>() as IState;
                break;
        }

        return state;
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
        _container.Instantiate<StandingPlayerState>();
    }
}