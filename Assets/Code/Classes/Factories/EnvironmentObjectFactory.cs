/**
 * FTSWFOS - EnvironmentObjectFactory - Concrete Class
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

/**************************************/
/***** ENVIRONMENT OBJECT FACTORY *****/
/**************************************/

public class EnvironmentObjectFactory : AbstractDIFactory<IEnvironmentObject>, IEnvironmentObjectFactory<IEnvironmentObject>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var EnvironmentObjectType _type type of foe
     * @var List<GameObject> _gameObjects game objects to use
     */

    protected EnvironmentObjectType _type;
    protected List<GameObject> _gameObjects;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param EnvironmentObjectType type type of environment object
     * @param List<GameObject> gameObjects game objects to use
     */

    public EnvironmentObjectFactory(DiContainer container, List<GameObject> gameObjects, EnvironmentObjectType type = EnvironmentObjectType.Back) : base(container)
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

    public EnvironmentObjectType Type
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
     * @return IEnvironmentObject
     */

    public override IEnvironmentObject Create(params object[] constructorArguments)
    {
        IEnvironmentObject environmentObject;
        GameObject prefab;

        switch (_type)
        {
            case EnvironmentObjectType.Back:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                _container.Bind<IEnvironmentObject>().To<Back>().AsTransient();
                environmentObject = _container.InstantiateComponent<Back>(prefab, new object[] {});
                break;
            case EnvironmentObjectType.Front:
                prefab = _container.InstantiatePrefab(_gameObjects[2]);
                _container.Bind<IEnvironmentObject>().To<Front>().AsTransient();
                environmentObject = _container.InstantiateComponent<Front>(prefab, new object[] { });
                break;
            case EnvironmentObjectType.Middle:
                prefab = _container.InstantiatePrefab(_gameObjects[1]);
                _container.Bind<IEnvironmentObject>().To<Middle>().AsTransient();
                environmentObject = _container.InstantiateComponent<Middle>(prefab, new object[] { });
                break;
            default:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                _container.Bind<IEnvironmentObject>().To<Back>().AsTransient();
                environmentObject = _container.InstantiateComponent<Back>(prefab, new object[] { });
                break;
        }

        environmentObject.Type = _type;
        return environmentObject;
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