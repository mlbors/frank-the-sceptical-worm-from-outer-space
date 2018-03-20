/**
 * FTSWFOS - AbstractPlayerState - Abstract Class
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

/*********************************/
/***** ABSTRACT PLAYER STATE *****/
/*********************************/

abstract public class AbstractPlayerState : AbstractInputHandler, IPlayerState
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IPlayer _player player
     */

    protected IPlayer _player;

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** PLAYER GETTER/SETTER *****/
    /********************************/

    /*
     * @access public
     */

    public IPlayer Player
    {
        get { return _player; }
        set { _player = value; }
    }

    /**************************************************/
    /**************************************************/

    /************************/
    /***** PLAYER STATE *****/
    /************************/

    /*
     * @access public
     */

    public AbstractPlayerState(IPlayer player)
    {
        _player = player;   
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** ENTER *****/
    /*****************/

    /*
     * @access public
     */

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /*
     * @access public
     */

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
