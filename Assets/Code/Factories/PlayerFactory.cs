/**
 * FTSWFOS - PlayerFactory - Concrete Class
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
/***** PLAYER FACTORY *****/
/**************************/

public class PlayerFactory : AbstractDIFactory
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     */

    public PlayerFactory(DiContainer container) : base (container)
    {
  
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return IPlayer
     */

    public override IPlayer Create<IPlayer, IProduct>(params object[] constructorArguments)
    {
        IPlayer player;

        player = _container.Instantiate<Player>() as IPlayer;

        return player;
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
        _container.Instantiate<Player>();
    }
}