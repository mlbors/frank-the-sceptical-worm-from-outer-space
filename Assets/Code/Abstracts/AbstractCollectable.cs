/**
 * FTSWFOS - AbstractCollectable - Abstract Class
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

/********************************/
/***** ABSTRACT COLLECTABLE *****/
/********************************/

abstract public class AbstractCollectable : MonoBehaviour, ICollectable, IObservable, IProduct, ISoundingObject
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Float _x x position
     * @var Float _y y position;
     * @var List<IObserver> _observers list of observers
     * @var AudioSource _sound sound to use
     */

    protected float _x;
    protected float _y;
    protected List<IObserver> _observers;
    protected AudioSource _sound;

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
    /***** SOUND GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public AudioSource Sound
    {
        get { return _sound; }
        set { _sound = value; }
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

    void IObservable.Attach(IObserver observer)
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

    void IObservable.Detach(IObserver observer)
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
     */

    void IObservable.Notify()
    {
        foreach (IObserver o in _observers)
        {
            o.ObserverUpdate();
        }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** ICOLLECTABLE PERFORM *****/
    /********************************/

    /**
     * @access public
     */

    public abstract void Perform();

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** ISOUNDING OBEJCT PLAY SOUND *****/
    /***************************************/

    /**
     * @access public
     */

    public abstract void PlaySound();

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ON TRIGGER ENTER 2D *****/
    /*******************************/

    /**
     * @access private
     */

    public abstract void OnTriggerEnter2D(Collision2D otherObject);
}
 