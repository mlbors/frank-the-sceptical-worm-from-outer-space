/**
 * FTSWFOS - CollectableGenerator - Concrete Class
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

/**************************************************/
/**************************************************/

/*********************************/
/***** COLLECTABLE GENERATOR *****/
/*********************************/

public class CollectableGenerator : AbstractGenerator<ICollectable>, ICollectableGenerator, IObserver, IObservable
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var CollectableType _lastCollectableType type of the last generated object
     * @var CollectableType _currentType type of the current generated object
     * @var IObjectComputer _objectComputer contains algorithm to compute required object
     * @var IObjectComputerFactory _objectComputerFactory object that create other objects, here, IObjectComputer
     * @var Dictionary<string, IObjectComputer> _objectComputers dictionary of needed various object computers
     * @var List<IObserver> _observers list of observers
     * @var bool  _poolInitialized tells if pool was initialized
     * @var bool _gameOperatorAttached tells if gameOperator was attached to composites
     * @var bool _scoreOperatorAttached tells if scoreOperator was attached to composites  
     */

    protected CollectableType _lastCollectableType = CollectableType.Death;
    protected CollectableType _currentType = CollectableType.Death;
    protected IObjectComputer _objectComputer;
    protected IObjectComputerFactory<IObjectComputer> _objectComputerFactory;
    protected Dictionary<string, IObjectComputer> _objectComputers = new Dictionary<string, IObjectComputer>();
    protected List<IObserver> _observers = new List<IObserver>();
    protected bool _poolInitialized;
    protected bool _gameOperatorAttached;
    protected bool _scoreOperatorAttached;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IObjectComputerFactory objectComputerFactory object that create other objects, here, IObjectComputer
     */

    public CollectableGenerator(IObjectComputerFactory<IObjectComputer> objectComputerFactory) : base()
    {
        _objectComputerFactory = objectComputerFactory;
    }

    /**************************************************/
    /**************************************************/

    /*****************************************/
    /***** OBJECT COMPUTER GETTER/SETTER *****/
    /*****************************************/

    public IObjectComputer ObjectComputer
    {
        get { return _objectComputer; }
        set { _objectComputer = value; }
    }

    /**************************************************/
    /**************************************************/

    /*************************************************/
    /***** OBJECT COMPUTER FACTORY GETTER/SETTER *****/
    /*************************************************/

    public IObjectComputerFactory<IObjectComputer> ObjectComputerFactory
    {
        get { return _objectComputerFactory; }
        set { _objectComputerFactory = value; }
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

    /****************/
    /***** INIT *****/
    /****************/

    /**
     * @access public
     */

    public override void Init()
    {
        _objectComputerFactory.Type = ObjectComputerType.Bonus;
        _objectComputers["bonus"] = _objectComputerFactory.Create();

        _objectComputerFactory.Type = ObjectComputerType.Death;
        _objectComputers["death"] = _objectComputerFactory.Create();

        _objectComputerFactory.Type = ObjectComputerType.NegativeBonus;
        _objectComputers["negative"] = _objectComputerFactory.Create();

        _objectComputerFactory.Type = ObjectComputerType.PowerUp;
        _objectComputers["powerup"] = _objectComputerFactory.Create();
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
                    foreach (KeyValuePair<string, IObjectComputer> objectComputer in _objectComputers)
                    {
                        (objectComputer.Value as IPlatformObjectComputer).GameOperator = (data as IOperator);
                    }
                    (_pool as ICollectablePool).GameOperator = (data as IOperator);
                    _gameOperatorAttached = true;
                    break;
                case ObservableEventType.ScoreInitialized:
                    foreach (KeyValuePair<string, IObjectComputer> objectComputer in _objectComputers)
                    {
                        (objectComputer.Value as IPlatformObjectComputer).ScoreOperator = (data as IOperatorElement);
                    }
                    (_pool as ICollectablePool).ScoreOperator = (data as IOperatorElement);
                    _scoreOperatorAttached = true;
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

    /********************/
    /***** GENERATE *****/
    /********************/

    public override void Generate()
    {
        try 
        {
            if (!_CheckIfPoolInitialized())
            {
                return;
            }

            _lastCollectableType = _currentType;
            _currentType = _GetRandomCollectableType();
            (_pool as ICollectablePool).NeedType = _currentType;

            switch (_currentType)
            {
                case CollectableType.Bonus:
                    _objectComputer = _objectComputers["bonus"];
                    break;

                case CollectableType.Death:
                    _objectComputer = _objectComputers["death"];
                    break;

                case CollectableType.NegativeBonus:
                    _objectComputer = _objectComputers["negative"];
                    break;

                case CollectableType.PowerUp:
                    _objectComputer = _objectComputers["powerup"];
                    break;

                default:
                    _objectComputer = _objectComputers["bonus"];
                    break;
            }

            _GenerateCollectables();
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /*****************************************/
    /***** CHECK IF POOL WAS INITIALIZED *****/
    /*****************************************/

    /**
     * @access protected
     * @return bool    
     */

    protected bool _CheckIfPoolInitialized()
    {
        if (_pool == null)
        {
            return false;
        }

        if (_poolInitialized)
        {
            return true;
        }

        if (!_poolInitialized && _gameOperatorAttached && _scoreOperatorAttached)
        {
            _pool.Init();
            _poolInitialized = true;
            return true;
        }

        return false;
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** GET RANDOM COLLECTABLE TYPE *****/
    /***************************************/

    /**
     * @access protected
     * @return CollectableType
     */

    protected CollectableType _GetRandomCollectableType()
    {
        if (_lastCollectableType != CollectableType.Bonus)
        {
            return CollectableType.Bonus;
        }

        Array values = Enum.GetValues(typeof(CollectableType));
        System.Random random = new System.Random();
        return (CollectableType)values.GetValue(random.Next(values.Length));
    }

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** GENERATE COLLECTABLES *****/
    /*********************************/

    /**
     * @access protected
     */

    protected void _GenerateCollectables()
    {
        (_objectComputer as IObjectComputer<ICollectable>).Pool = _pool;
        _objectComputer.ReferenceObject = _referenceObject;
        _objectComputer.ExecuteComputation();

        foreach (ICollectable collectable in (_objectComputer as IObjectComputer<ICollectable>).GeneratedObjects)
        {
            PlatformObjectData data = new PlatformObjectData()
            {
                Type = (PlatformObjectDataType)Enum.Parse(typeof(PlatformObjectDataType), _currentType.ToString()),
                X = collectable.X,
                Y = collectable.Y,
                Width = collectable.Width,
                Height = collectable.Height
            };

            Notify(ObservableEventType.PlatformObjectAdded, data);
        }
    }
}
