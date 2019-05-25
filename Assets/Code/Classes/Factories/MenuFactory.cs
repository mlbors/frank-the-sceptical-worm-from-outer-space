/**
 * FTSWFOS - MenuFactory - Concrete Class
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

/************************/
/***** MENU FACTORY *****/
/************************/

public class MenuFactory : AbstractDIFactory<IMenu>, IMenuFactory<IMenu>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var MenuType _type type of menu
     * @var List<GameObject> _gameObjects game objects to use
     * @var GameObject _canvas canvas to use to render objects    
     * @var IOperator _gameOperator object managing game          
     */

    protected MenuType _type;
    protected List<GameObject> _gameObjects;
    protected GameObject _canvas;
    protected IOperator _gameOperator;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param MenuType type type of foe
     * @param List<GameObject> gameObjects game objects to use
     */

    public MenuFactory(DiContainer container, List<GameObject> gameObjects, GameObject canvas, MenuType type = MenuType.Main) : base(container)
    {
        _gameObjects = gameObjects;
        _canvas = canvas;
        _type = type;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** TYPE GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public MenuType Type
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

    /********************************/
    /***** CANVAS GETTER/SETTER *****/
    /********************************/

    /**
     * @access public
     */

    public GameObject Canvas
    {
        get { return _canvas; }
        set { _canvas = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** GAME OPERATOR GETTER/SETTER *****/
    /***************************************/

    public IOperator GameOperator
    {
        get { return _gameOperator; }
        set { _gameOperator = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return IMenu
     */

    public override IMenu Create(params object[] constructorArguments)
    {
        IMenu menu;
        GameObject prefab;

        switch (_type)
        {
            case MenuType.Death:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                prefab.transform.SetParent(_canvas.transform, false);
                _container.Bind<IMenu>().To<DeathMenu>().AsTransient();
                menu = _container.InstantiateComponent<DeathMenu>(prefab, new object[] {});
                break;
            case MenuType.Main:
                prefab = _container.InstantiatePrefab(_gameObjects[1]);
                prefab.transform.SetParent(_canvas.transform, false);
                _container.Bind<IMenu>().To<MainMenu>().AsTransient();
                menu = _container.InstantiateComponent<MainMenu>(prefab, new object[] { });
                break;
            case MenuType.Pause:
                prefab = _container.InstantiatePrefab(_gameObjects[2]);
                prefab.transform.SetParent(_canvas.transform, false);
                _container.Bind<IMenu>().To<PauseMenu>().AsTransient();
                menu = _container.InstantiateComponent<PauseMenu>(prefab, new object[] { });
                break;
            default:
                prefab = _container.InstantiatePrefab(_gameObjects[1]);
                prefab.transform.SetParent(_canvas.transform, false);
                _container.Bind<IMenu>().To<DeathMenu>().AsTransient();
                menu = _container.InstantiateComponent<DeathMenu>(prefab, new object[] { });
                break;

        }

        (menu as IObservable).Attach(_gameOperator as IObserver);
        return menu;
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