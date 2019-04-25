/**
 * FTSWFOS - FoeOperatorElement - Concrete Class
 *
 * @since       2018.01.09
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/**************************************************/
/**************************************************/

/********************************/
/***** FOE OPERATOR ELEMENT *****/
/********************************/

public class FoeOperatorElement : AbstractGeneratorComponentOperatorElement<IFoe>, IObserver, IObservable
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IObserver> _observers list of observers
     * @var bool _gameOperatorAttached tells if gameOperator was attached to composites
     * @var bool _scoreOperatorAttached tells if scoreOperator was attached to composites    
     * @var IOperator _gameOperator object to pass to composites
     * @var IOperatorElement _scoreOperator object to pass to composites   
     */

    protected List<IObserver> _observers = new List<IObserver>();
    protected bool _gameOperatorAttached;
    protected bool _scoreOperatorAttached;
    protected IOperator _gameOperator;
    protected IOperatorElement _scoreOperator;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @param IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
     * @param IPoolFactory poolFactory factory object that creates other objects, here, IPool
     */

    [Inject]
    public override void Construct(IGeneratorFactory<IGenerator> generatorFactory,
                                   IDestroyerFactory<IDestroyer> destroyerFactory,
                                   IPoolFactory<IPool> poolFactory)
    {
        base.Construct(generatorFactory, destroyerFactory, poolFactory);
    }

    /**************************************************/
    /**************************************************/

    /***********************************/
    /***** OBSERVERS GETTER/SETTER *****/
    /***********************************/

    /**
     * @access public
     */

    public List<IObserver> Observers
    {
        get { return _observers; }
        set { _observers = value; }
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    public override void Init()
    {
        try
        {
            _SetPool();
            _SetDestroyer();
            _SetGenerator();
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** SET POOL *****/
    /********************/

    /**
     * @access protected
     */

    protected void _SetPool()
    {
        _poolFactory.Type = PoolType.Foe;
        Pool = _poolFactory.Create();
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** SET DESTROYER *****/
    /*************************/

    /**
     * @access protected
     */

    protected void _SetDestroyer()
    {
        _destroyerFactory.Type = DestroyerType.Foe;
        Destroyer = _destroyerFactory.Create() as IDestroyer<IFoe>;
        _destroyer.Pool = _pool as IPool<IFoe>;
        _destroyer.ReferenceObject = _referenceObject;
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** SET GENERATOR *****/
    /*************************/

    /**
     * @access protected
     */

    protected void _SetGenerator()
    {
        _generatorFactory.Type = GeneratorType.Foe;
        Generator = _generatorFactory.Create() as IGenerator<IFoe>;
        _generator.Pool = _pool as IPool<IFoe>;
        _generator.ReferenceObject = _referenceObject;
        _generator.Init();
        Attach(_generator as IObserver);
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** OPERATORELEMENT - OPERATE *****/
    /*************************************/

    public override void Operate()
    {
        try
        {
            _NotifyGenerators(ObservableEventType.GameInitialized, _gameOperator);
            _NotifyGenerators(ObservableEventType.ScoreInitialized, _scoreOperator);

            switch (_requiredAction)
            {
                case "generate":
                    CallGenerator();
                    break;
                case "destroy":
                    CallDestroyer();
                    break;
                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /******************************************************/
    /***** IGENERATOR OPERATOR ELEMENT CALL GENERATOR *****/
    /******************************************************/

    public override void CallGenerator()
    {
        _generator.Generate();
    }

    /**************************************************/
    /**************************************************/

    /******************************************************/
    /***** IGENERATOR OPERATOR ELEMENT CALL DESTROYER *****/
    /******************************************************/

    public override void CallDestroyer()
    {
        _destroyer.Destroy();
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     */

    public void ObserverUpdate(ObservableEventType info, object data)
    {
        try
        {
            switch (info)
            {
                case ObservableEventType.GameInitialized:
                    _NotifyGenerators(ObservableEventType.GameInitialized, data);
                    break;
                case ObservableEventType.ScoreInitialized:
                    _NotifyGenerators(ObservableEventType.ScoreInitialized, data);
                    break;
                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IOBSERVABLE - ATTACH *****/
    /********************************/

    /**
     * @access private
     * @param IObserver observer observer to attach
     */

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IOBSERVABLE - DETACH *****/
    /********************************/

    /**
     * @access private
     * @param IObserver observer observer to detach
     */

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** IOBSERVABLE NOTIFY *****/
    /******************************/

    /**
     * @access private
     * @param String info info for update
     */

    public void Notify(ObservableEventType info, object data)
    {
        foreach (IObserver o in _observers)
        {
            o.ObserverUpdate(info, data);
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** NOTIFY GENERATOR *****/
    /****************************/

    /**
     * @param object data object to pass
     * @param ObservableEventType info info for update    
     * @access protected
     */

    protected void _NotifyGenerators(ObservableEventType info, object data)
    {
        if (_observers.Count < 1)
        {
            switch (info)
            {
                case ObservableEventType.GameInitialized:
                    if (!_gameOperatorAttached)
                    {
                        _gameOperator = (data as IOperator);
                    }
                    break;

                case ObservableEventType.ScoreInitialized:
                    if (!_scoreOperatorAttached)
                    {
                        _scoreOperator = (data as IOperatorElement);
                    }
                    break;
            }
            return;
        }

        switch (info)
        {
            case ObservableEventType.GameInitialized:
                if (data != null && !_gameOperatorAttached)
                {
                    _gameOperator = (data as IOperator);
                    Notify(ObservableEventType.GameInitialized, data);
                    _gameOperatorAttached = true;
                }
                break;

            case ObservableEventType.ScoreInitialized:
                if (data != null && !_scoreOperatorAttached)
                {
                    _scoreOperator = (data as IOperatorElement);
                    Notify(ObservableEventType.ScoreInitialized, data);
                    _scoreOperatorAttached = true;
                }
                break;
        }
    }
}