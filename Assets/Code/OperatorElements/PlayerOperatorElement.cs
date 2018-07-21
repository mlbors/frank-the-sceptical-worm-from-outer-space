/**
 * FTSWFOS - PlayerOperatorElement - Concrete Class
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

/**************************************************/
/**************************************************/

/***********************************/
/***** PLAYER OPERATOR ELEMENT *****/
/***********************************/

public class PlayerOperatorElement : IOperatorElement
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IPlayer _player player object
     * @var IPlayerFactory playerFactory factory object that creates other objects, here, IPlayer
     */

    protected IPlayer _player;
    protected IPlayerFactory<IPlayer> _playerFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IPlayerFactory playerFactory factory object that creates other objects, here, IPlayer
     */

    public PlayerOperatorElement(IPlayerFactory<IPlayer> playerFactory)
    {
        _SetValues(playerFactory);
    }

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param IPlayerFactory playerFactory factory object that creates other objects, here, IPlayer
     */

    protected void _SetValues(IPlayerFactory<IPlayer> playerFactory)
    {
        PlayerFactory = playerFactory;
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** PLAYER FACTORY GETTER/SETTER *****/
    /****************************************/

    /**
     * @access public
     */

    public IPlayerFactory<IPlayer> PlayerFactory
    {
        get { return _playerFactory; }
        set { _playerFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** PLAYER FACTORY GETTER/SETTER *****/
    /****************************************/

    /**
     * @access public
     */

    public IPlayer Player
    {
        get { return _player; }
        set { _player = value; }
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    public void Init()
    {
        Player = _playerFactory.Create();
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** OPERATORELEMENT - OPERATE *****/
    /*************************************/

    public void Operate()
    {
        
    }
}