/**
 * FTSWFOS - CollectableOperatorElement - Concrete Class
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

/****************************************/
/***** COLLECTABLE OPERATOR ELEMENT *****/
/****************************************/

public class CollectableOperatorElement : AbstractGeneratorComponentOperatorElement<ICollectable>, IObserver, IObservable
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IObserver> _observers list of observers
     * @var bool _observersNotified tells if composites were notified   
     * @var IOperatorElement _scoreOperator object to pass to composites    
     */

    protected List<IObserver> _observers = new List<IObserver>();
    protected bool _observersNotified;
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
            Logger.LogMessage(e);
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
        _poolFactory.Type = PoolType.Collectable;
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
        _destroyerFactory.Type = DestroyerType.Collectable;
        Destroyer = _destroyerFactory.Create() as IDestroyer<ICollectable>;
        _destroyer.Pool = _pool as IPool<ICollectable>;
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
        _generatorFactory.Type = GeneratorType.Collectable;
        Generator = _generatorFactory.Create() as IGenerator<ICollectable>;
        _generator.Pool = _pool as IPool<ICollectable>;
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
            _NotifyGenerator(_scoreOperator);

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
            Logger.LogMessage(e);
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
                case ObservableEventType.ScoreInitialized:
                    _NotifyGenerator(data);
                    break;
                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Logger.LogMessage(e);
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
     * @access protected
     */

    protected void _NotifyGenerator(object data)
    {
        if (_observers.Count == 0)
        {
            if (!_observersNotified)
            {
                _scoreOperator = (data as IOperatorElement);
            }
            return;
        }

        if (data == null || _observersNotified)
        {
            return;
        }

        Notify(ObservableEventType.ScoreInitialized, data);
        _observersNotified = true;
    }
}