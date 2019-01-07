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
     * @var CollectableType _type type of collectable
     * @var Float _x x position
     * @var Float _y y position;
     * @var List<IObserver> _observers list of observers
     * @var AudioSource _sound sound to use
     */

    protected CollectableType _type;
    protected float _x;
    protected float _y;
    protected List<IObserver> _observers = new List<IObserver>();
    protected AudioSource _sound;

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** TYPE GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public CollectableType Type
    {
        get { return _type; }
        set { _type = value; }
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

    public void Notify(string info, object data)
    {
        foreach (IObserver o in _observers)
        {
            o.ObserverUpdate(info, null);
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
     * @access public
     */

    public virtual void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "Player" && otherObject.GetType() == typeof(CircleCollider2D))
        {
            PlaySound();
            Perform();
            (this as MonoBehaviour).gameObject.SetActive(false);
        }
    }
}
 