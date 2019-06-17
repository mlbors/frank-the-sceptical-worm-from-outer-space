/**
 * FTSWFOS - AbstractDeathBox - Abstract Class
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

/******************************/
/***** ABSTRACT DEATH BOX *****/
/******************************/

abstract public class AbstractDeathBox : MonoBehaviour, IDeathBox, IObservable, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Float _x x position
     * @var Float _y y position
     * @var Float _width width of the object
     * @var Float _height height of the object
     * @var List<IObserver> _observers list of observers
     * @var MonoBehaviour _targetObject object to follow  
     * @var Bool _initialized tells if deathbox is initialized
     * @var Bool _resetting tells if deathbox is resetting   
     */

    protected float _x;
    protected float _y;
    protected float _width;
    protected float _height;
    protected List<IObserver> _observers = new List<IObserver>();
    protected MonoBehaviour _targetObject;
    protected bool _initialized = false;
    protected bool _resetting = false;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     */

    [Inject]
    public virtual void Construct()
    {
       
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** X GETTER/SETTER *****/
    /***************************/

    /**
     * @access public
     */

    public float X
    {
        get { return _x; }
        set { _x = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** Y GETTER/SETTER *****/
    /***************************/

    /**
     * @access public
     */

    public float Y
    {
        get { return _y; }
        set { _y = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** WIDTH GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public float Width
    {
        get { return _width; }
        set { _width = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** HEIGHT GETTER/SETTER *****/
    /********************************/

    /**
     * @access public
     */

    public float Height
    {
        get { return _height; }
        set { _height = value; }
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

    /***********************************/
    /***** RESETTING GETTER/SETTER *****/
    /***********************************/

    /**
     * @access public
     */

    public bool Resetting
    {
        get { return _resetting; }
        set { _resetting = value; }
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
    /***** RESET *****/
    /*****************/

    /**
     * @access public
     */

    public virtual void Reset()
    {
        transform.position = new Vector3(0.00f, 0.00f, transform.position.z);
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** AWAKE *****/
    /*****************/

    /**
     * @access public
     */

    public abstract void Awake();

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access public
     */

    public abstract void Start();

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /**
     * @access public
     */

    public abstract void Update();

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** IDEATH BOX OPERATE *****/
    /******************************/

    /**
     * @access public
     */

    public abstract void Operate();

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ON TRIGGER ENTER 2D *****/
    /*******************************/

    /**
     * @access private
     */

    public abstract void OnTriggerEnter2D(Collider2D otherObject);
}
 