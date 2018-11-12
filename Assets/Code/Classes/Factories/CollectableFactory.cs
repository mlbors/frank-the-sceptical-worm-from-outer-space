/**
 * FTSWFOS - CollectableFactory - Concrete Class
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

/*******************************/
/***** COLLECTABLE FACTORY *****/
/*******************************/

public class CollectableFactory : AbstractDIFactory<ICollectable>, ICollectableFactory<ICollectable>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var CollectableType _type type of collectable
     * @var List<GameObject> _gameObjects game objects to use
     */

    protected CollectableType _type;
    protected List<GameObject> _gameObjects;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param CollectableType type type of collectable
     * @param List<GameObject> gameObjects game objects to use
     */

    public CollectableFactory(DiContainer container, List<GameObject> gameObjects, CollectableType type = CollectableType.Bonus) : base(container)
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

    public CollectableType Type
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
     * @return ICollectable
     */

    public override ICollectable Create(params object[] constructorArguments)
    {
        ICollectable collectable;
        GameObject prefab;

        switch (_type)
        {
            case CollectableType.Bonus:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                //_container.Bind<ICollectable>().To<Bonus>().AsTransient();
                //collectable = _container.InstantiateComponent<Bonus>(prefab, new object[] {});
                break;
            default:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                //_container.Bind<ICollectable>().To<Bonus>().AsTransient();
                //collectable = _container.InstantiateComponent<Bonus>(prefab, new object[] {});
                break;
        }

        return collectable;
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