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
     */

    protected float _x;
    protected float _y;
    protected float _width;
    protected float _height;
    protected List<IObserver> _observers = new List<IObserver>();

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
 