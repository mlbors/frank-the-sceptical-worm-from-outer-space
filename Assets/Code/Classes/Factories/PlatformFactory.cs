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
     * @var PlatformType _type type of platform
     * @var List<GameObject> _gameObjects game objects to use
     */

    protected PlatformType _type;
    protected List<GameObject> _gameObjects;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param PlatformType type type of platform
     * @param List<GameObject> _gameObjects game objects to use
     */

    public PlatformFactory(DiContainer container, List<GameObject> gameObjects, PlatformType type = PlatformType.One) : base(container)
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

    public PlatformType Type
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
        GameObject prefab;

        switch (_type)
        {
            case PlatformType.One:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                break;
            case PlatformType.Two:
                prefab = _container.InstantiatePrefab(_gameObjects[1]);
                break;
            case PlatformType.Four:
                prefab = _container.InstantiatePrefab(_gameObjects[2]);
                break;
            case PlatformType.Five:
                prefab = _container.InstantiatePrefab(_gameObjects[3]);
                break;
            case PlatformType.Seven:
                prefab = _container.InstantiatePrefab(_gameObjects[4]);
                break;
            case PlatformType.Nine:
                prefab = _container.InstantiatePrefab(_gameObjects[5]);
                break;
            default:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                break;
        }

        _container.Bind<IPlatform>().To<Platform>().AsTransient();
        platform = _container.InstantiateComponent<Platform>(prefab);

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
        _container.Instantiate<Platform>();
    }
}