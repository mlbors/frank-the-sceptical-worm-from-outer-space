/**
 * FTSWFOS - PlatformFactory - Concrete Class
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

/****************************/
/***** PLATFORM FACTORY *****/
/****************************/

public class PlatformFactory : AbstractDIFactory<IPlatform>, IPlatformFactory<IPlatform>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var PlatformTypes _type type of platform
     * @var List<GameObject> _gameObjects game objects to use
     */

    protected PlatformTypes _type;
    protected List<GameObject> _gameObjects;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param PlatformTypes type type of platform
     * @param List<GameObject> _gameObjects game objects to use
     */

    public PlatformFactory(DiContainer container, PlatformTypes type, List<GameObject> gameObjects) : base (container)
    {
        _type = type;
        _gameObjects = gameObjects;
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** TYPES GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public PlatformTypes Type
    {
        get { return _type; }
        set { _type = value; }
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** GAME OBJECTS GETTER/SETTER *****/
    /**************************************/

    /**
     * @access public
     */

    public List<GameObject> GameObjects
    {
        get { return _gameObjects; }
        set { _gameObjects = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return IPlatform
     */

    public override IPlatform Create(params object[] constructorArguments)
    {
        IPlatform platform;

        switch (_type)
        {
            case PlatformTypes.One:
                platform = _container.Instantiate<Platform>(new object[] {}) as IPlatform;
                break;
            case PlatformTypes.Two:
                platform = _container.Instantiate<Platform>(new object[] {}) as IPlatform;
                break;
            case PlatformTypes.Four:
                platform = _container.Instantiate<Platform>(new object[] {}) as IPlatform;
                break;
            case PlatformTypes.Five:
                platform = _container.Instantiate<Platform>(new object[] {}) as IPlatform;
                break;
            case PlatformTypes.Seven:
                platform = _container.Instantiate<Platform>(new object[] {}) as IPlatform;
                break;
            case PlatformTypes.Nine:
                platform = _container.Instantiate<Platform>(new object[] {}) as IPlatform;
                break;
            default:
                platform = _container.Instantiate<Platform>(new object[] {}) as IPlatform;
                break;
        }

        return platform;
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

    }
}