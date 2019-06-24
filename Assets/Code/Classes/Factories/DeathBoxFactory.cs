/**
 * FTSWFOS - DeathBoxFactory - Concrete Class
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

/*****************************/
/***** DEATH BOX FACTORY *****/
/*****************************/

public class DeathBoxFactory : AbstractDIFactory<IDeathBox>, IDeathBoxFactory<IDeathBox>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var GameObject _gameObject game object to use
     * @var MonoBehaviour _targetObject object to follow    
     * @var IOperator _gameOperator object managing game 
     * @var IOperatorElement _scoreOperator object managing score 
     */

    protected GameObject _gameObject;
    protected MonoBehaviour _targetObject;
    protected IOperator _gameOperator;
    protected IOperatorElement _scoreOperator;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param GameObject _gameObject game object to use
     */

    public DeathBoxFactory(DiContainer container, GameObject gameObject) : base(container)
    {
        _gameObject = gameObject;
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** GAME OBJECT GETTER/SETTER *****/
    /*************************************/

    /**
     * @access public
     */

    public GameObject GameObject
    {
        get { return _gameObject; }
        set { _gameObject = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** TARGET OBJECT GETTER/SETTER *****/
    /***************************************/

    /**
     * @access public
     */

    public MonoBehaviour TargetObject
    {
        get { return _targetObject; }
        set { _targetObject = value; }
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
     * @return IDeathBox
     */

    public override IDeathBox Create(params object[] constructorArguments)
    {
        IDeathBox deathBox;
        GameObject prefab;

        prefab = _container.InstantiatePrefab(_gameObject);
        _container.Bind<IDeathBox>().To<DeathBox>().AsSingle();
        deathBox = _container.InstantiateComponent<DeathBox>(prefab, new object[] { });

        (deathBox as IObservable).Attach(_gameOperator as IObserver);
        (deathBox as IObservable).Attach(_scoreOperator as IObserver);
        return deathBox;
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