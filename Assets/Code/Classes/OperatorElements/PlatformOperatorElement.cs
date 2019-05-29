/**
 * FTSWFOS - PlatformOperatorElement - Concrete Class
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

/*************************************/
/***** PLATFORM OPERATOR ELEMENT *****/
/*************************************/

public class PlatformOperatorElement : AbstractGeneratorOperatorElement<IPlatform>, IPlatformOperatorElement, IObserver, IObservable
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
     * @param IOperatorElementFactory<IOperatorElement> operatorElementFactory object that create other objects, here, IOperatorElementFactory
     */

    [Inject]
    public override void Construct(IGeneratorFactory<IGenerator> generatorFactory,
                                   IDestroyerFactory<IDestroyer> destroyerFactory,
                                   IPoolFactory<IPool> poolFactory,
                                   IOperatorElementFactory<IOperatorElement> operatorElementFactory)
    {
        base.Construct(generatorFactory, destroyerFactory, poolFactory, operatorElementFactory);
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
            _SetInitialOffset();
            _SetPool();
            _SetDestroyer();
            _SetGenerator();
            _SetComposites();
            _InitDestroyer();
            _InitGenerator();
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** SET INITIAL OFFSET *****/
    /******************************/

    /**
     * @access protected
     */

    protected void _SetInitialOffset()
    {
        GameObject initialPlatform = GameObject.Find("InitialPlatform");
        float initialPlatformWidth = initialPlatform.GetComponent<BoxCollider2D>().size.x;
        float initialPlatformXPos = initialPlatform.transform.position.x;
        transform.position = new Vector3(initialPlatformWidth / 2 + initialPlatformXPos, transform.position.y, transform.position.z);
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
        _poolFactory.Type = PoolType.Platform;
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
        _destroyerFactory.Type = DestroyerType.Platform;
        Destroyer = _destroyerFactory.Create() as IDestroyer<IPlatform>;
        _destroyer.Pool = _pool as IPool<IPlatform>;
        _destroyer.ReferenceObject = this;
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
        _generatorFactory.Type = GeneratorType.Platform;
        Generator = _generatorFactory.Create() as IGenerator<IPlatform>;
        _generator.Pool = _pool as IPool<IPlatform>;
        _generator.ReferenceObject = this;
        _generator.Init();
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** SET COMPOSITES *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _SetComposites()
    {
        _operatorElementFactory.Type = OperatorElementType.FoeOperatorElement;
        IOperatorElement foeOperatorElement = _operatorElementFactory.Create();
        (foeOperatorElement as IGeneratorComponentOperatorElement).ReferenceObject = this;

        Attach(foeOperatorElement as IObserver);
        (_destroyer as IDestroyerComposite).AddOperatorElement(foeOperatorElement);
        (_generator as IGeneratorComposite).AddOperatorElement(foeOperatorElement);

        _operatorElementFactory.Type = OperatorElementType.CollectableOperatorElement;
        IOperatorElement collectableOperatorElement = _operatorElementFactory.Create();
        (collectableOperatorElement as IGeneratorComponentOperatorElement).ReferenceObject = this;

        Attach(collectableOperatorElement as IObserver);
        (_destroyer as IDestroyerComposite).AddOperatorElement(collectableOperatorElement);
        (_generator as IGeneratorComposite).AddOperatorElement(collectableOperatorElement);
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** INIT DESTROYER *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _InitDestroyer()
    {
        _destroyer.Init();
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** INIT GENERATOR *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _InitGenerator()
    {
        _generator.Init();
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
            _NotifyComposites(ObservableEventType.GameInitialized, _gameOperator);
            _NotifyComposites(ObservableEventType.ScoreInitialized, _scoreOperator);

            if (_generationPoint == null || _destructionPoint == null)
            {
                return;
            }

            if (_IsGenerationPointAhead())
            {
                CallGenerator();
                _MoveOperator();
                _generator.CurrentObject = null;
            }

            if (_IsDestructionPointBehind())
            {
                CallDestroyer();
            }
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
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
                case ObservableEventType.CameraCreated:
                    GenerationPoint = (data as List<Transform>)[0];
                    DestructionPoint = (data as List<Transform>)[1];
                    break;

                case ObservableEventType.GameInitialized:
                    _NotifyComposites(ObservableEventType.GameInitialized, data);
                    break;

                case ObservableEventType.GameRestarts:
                    _pool.Reset();
                    _SetInitialOffset();
                    Notify(ObservableEventType.GameRestarts, null);
                    break;

                case ObservableEventType.ScoreInitialized:
                    _NotifyComposites(ObservableEventType.ScoreInitialized, data);
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

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access public
     */

    public override void Start()
    {

    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /**
     * @access public
     */

    public override void Update()
    {
        Operate();
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** IS GENERATION POINT AHEAD *****/
    /*************************************/

    /**
     * @access protected
     * @return bool
     */

    protected bool _IsGenerationPointAhead()
    {
        return transform.position.x < _generationPoint.position.x;
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** IS DESTRUCTION POINT BEHIND *****/
    /***************************************/

    /**
     * @access protected
     * @return bool
     */

    protected bool _IsDestructionPointBehind()
    {
        return transform.position.x > _destructionPoint.position.x;
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** IS GENERATION POINT BEHIND *****/
    /**************************************/

    /**
     * @access protected
     */

    protected void _MoveOperator()
    {
        float generatedObjectWidth = (_generator.CurrentObject as MonoBehaviour).gameObject.GetComponent<BoxCollider2D>().size.x;
        float generatedObjectXPos = (_generator.CurrentObject as MonoBehaviour).gameObject.transform.position.x;
        transform.position = new Vector3(generatedObjectWidth/2 + generatedObjectXPos, transform.position.y, transform.position.z);
    }

    /**************************************************/
    /**************************************************/

    /*****************************/
    /***** NOTIFY COMPOSITES *****/
    /*****************************/

    /**
     * @param object data object to pass
     * @param ObservableEventType info info for update    
     * @access protected
     */

    protected void _NotifyComposites(ObservableEventType info, object data)
    {
        if (_observers.Count < 2)
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