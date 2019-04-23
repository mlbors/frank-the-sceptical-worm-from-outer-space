/**
 * FTSWFOS - FoeGenerator - Concrete Class
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

/*************************/
/***** FOE GENERATOR *****/
/*************************/

public class FoeGenerator : AbstractGenerator<IFoe>, IFoeGenerator, IObserver, IObservable
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var FoeType _lastFoeType type of the last generated object
     * @var FoeType _currentType type of the current generated object
     * @var IObjectComputer _objectComputer contains algorithm to compute required object
     * @var IObjectComputerFactory _objectComputerFactory object that create other objects, here, IObjectComputer
     * @var List<IObserver> _observers list of observers
     */

    protected FoeType _lastCollectableType = FoeType.Spike;
    protected FoeType _currentType = FoeType.Spike;
    protected IObjectComputer _objectComputer;
    protected IObjectComputerFactory<IObjectComputer> _objectComputerFactory;
    protected Dictionary<string, IObjectComputer> _objectComputers = new Dictionary<string, IObjectComputer>();
    protected List<IObserver> _observers = new List<IObserver>();

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IObjectComputerFactory objectComputerFactory object that create other objects, here, IObjectComputer
     */

    public FoeGenerator(IObjectComputerFactory<IObjectComputer> objectComputerFactory) : base()
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
        _objectComputerFactory.Type = ObjectComputerType.Spike;
        _objectComputers["spike"] = _objectComputerFactory.Create();
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
                    foreach (KeyValuePair<string, IObjectComputer> objectComputer in _objectComputers)
                    {
                        (objectComputer.Value as IPlatformObjectComputer).ScoreOperator = (data as IOperatorElement);
                    }
                    (_pool as IFoePool).ScoreOperator = (data as IOperatorElement);
                    _pool.Init();
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

    /********************/
    /***** GENERATE *****/
    /********************/

    public override void Generate()
    {
        try
        {
            _lastCollectableType = _currentType;
            _currentType = FoeType.Spike;
            (_pool as IFoePool).NeedType = _currentType;

            _objectComputer = _objectComputers["spike"];
            _GenerateFoes();
        }
        catch (Exception e)
        {
            Logger.LogMessage(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** GENERATE FOES *****/
    /*************************/

    /**
     * @access protected
     */

    protected void _GenerateFoes()
    {
        (_objectComputer as IObjectComputer<IFoe>).Pool = _pool;
        _objectComputer.ReferenceObject = _referenceObject;
        _objectComputer.ExecuteComputation();

        foreach (IFoe foe in (_objectComputer as IObjectComputer<IFoe>).GeneratedObjects)
        {
            PlatformObjectData data = new PlatformObjectData()
            {
                Type = (PlatformObjectDataType)Enum.Parse(typeof(PlatformObjectDataType), _currentType.ToString()),
                X = foe.X,
                Y = foe.Y,
                Width = foe.Width,
                Height = foe.Height
            };

            Notify(ObservableEventType.PlatformObjectAdded, data);
        }
    }
}
