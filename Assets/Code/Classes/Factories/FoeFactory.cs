/**
 * FTSWFOS - FoeFactory - Concrete Class
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

/***********************/
/***** FOE FACTORY *****/
/***********************/

public class FoeFactory : AbstractDIFactory<IFoe>, IFoeFactory<IFoe>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var FoeType _type type of foe
     * @var List<GameObject> _gameObjects game objects to use
     * @var IOperatorElement _scoreOperator object managing score     
     */

    protected FoeType _type;
    protected List<GameObject> _gameObjects;
    protected IOperatorElement _scoreOperator;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param FoeType type type of foe
     * @param List<GameObject> gameObjects game objects to use
     */

    public FoeFactory(DiContainer container, List<GameObject> gameObjects, FoeType type = FoeType.Spike) : base(container)
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

    public FoeType Type
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

    /****************************************/
    /***** SCORE OPERATOR GETTER/SETTER *****/
    /****************************************/

    public IOperatorElement ScoreOperator
    {
        get { return _scoreOperator; }
        set { _scoreOperator = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return IFoe
     */

    public override IFoe Create(params object[] constructorArguments)
    {
        IFoe foe;
        GameObject prefab;

        switch (_type)
        {
            case FoeType.Spike:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                _container.Bind<IFoe>().To<Spike>().AsTransient();
                foe = _container.InstantiateComponent<Spike>(prefab, new object[] {});
                break;
            default:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                _container.Bind<IFoe>().To<Spike>().AsTransient();
                foe = _container.InstantiateComponent<Spike>(prefab, new object[] { });
                break;
        }

        foe.Type = _type;
        (foe as IObservable).Attach(_scoreOperator as IObserver);
        return foe;
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