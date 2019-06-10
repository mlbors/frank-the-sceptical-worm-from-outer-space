/**
 * FTSWFOS - DeathBoxOperatorElement - Concrete Class
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

/**************************************/
/***** DEATH BOX OPERATOR ELEMENT *****/
/**************************************/

public class DeathBoxOperatorElement : MonoBehaviour, IOperatorElement, IDeathBoxOperatorElement
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IObserver> _observers list of observers
     * @var IDeathBox _deathBox death box object
     * @var IDeathBoxFactory deathBoxFactory factory object that creates other objects, here, DeathBox
     * @var MonoBehaviour _targetObject object to follow
     */

    protected List<IObserver> _observers = new List<IObserver>();
    protected IDeathBox _deathBox;
    protected IDeathBoxFactory<IDeathBox> _deathBoxFactory;
    protected MonoBehaviour _targetObject;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IDeathBoxFactory deathBoxFactory factory object that creates other objects, here, DeathBox
     */

    [Inject]
    public void Construct(IDeathBoxFactory<IDeathBox> deathBoxFactory)
    {

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

    /***********************************/
    /***** DEATH BOX GETTER/SETTER *****/
    /***********************************/

    /**
     * @access public
     */

    public IDeathBox DeathBox
    {
        get { return _deathBox; }
        set { _deathBox = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** DEATH BOX FACTORY GETTER/SETTER *****/
    /*******************************************/

    /**
     * @access public
     */

    public IDeathBoxFactory<IDeathBox> DeathBoxFactory
    {
        get { return _deathBoxFactory; }
        set { _deathBoxFactory = value; }
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

    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    /**
     * @access public
     */

    public void Init()
    {
        try
        {

        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** OPERATORELEMENT - OPERATE *****/
    /*************************************/

    /**
     * @access public
     */

    public void Operate()
    {
        try
        {

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

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access public
     */

    public void Start()
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

    public void Update()
    {

    }
}