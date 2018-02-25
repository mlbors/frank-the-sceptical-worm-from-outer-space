/**
 * FTSWFOS - CommandFactory - Interface
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

/**************************************************/
/**************************************************/

/***************************/
/***** COMMAND FACTORY *****/
/***************************/

public class CommandFactory<T, K> : AbstractFactory<T, K> where T : class, K, new()
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IPlayerState _state player's state
     */

    private IPlayerState _state;

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** STATE GETTER/SETTER *****/
    /*******************************/

    /*
     * @access public
     */

    public IPlayerState State
    {
        get { return _state; }
        set { _state = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @return T 
     */

    public override T Create()
    {
        return new T();   
    }
}