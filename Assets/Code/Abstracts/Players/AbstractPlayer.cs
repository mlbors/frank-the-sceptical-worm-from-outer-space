/**
 * FTSWFOS - AbstractPlayer - Abstract Class
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

/***************************/
/***** ABSTRACT PLAYER *****/
/***************************/

abstract public class AbstractPlayer : MonoBehaviour, ICameraTarget, ICommandSubject, IPlayerStateSubject, IObserver, IObservable, IPlayer, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Stack<IPlayerState> _statesStack stack of passed states, top is the current one
     * @var Rigibody2D _rigibody player rigidbody
     * @var IState _state player's state
     * @var IPlayerStateFactory _stateFactory object that create other objects, here, IState
     * @var List<IObserver> _observers list of observers
     * @var Bool _initialized tells if player is initialized
     * @var Float _moveSpeed player's move speed
     * @var Float _speedMultiplied how to increase player's speed
     * @var Float _speedMilestoneCount count number of passed milestones;
     * @var Float _speedIncreaseMilestone tells when player's speed must be increased
     */

    protected Rigidbody2D _rigidbody;
    protected Animator _animator;
    protected IPlayerState _state;
    protected IPlayerStateFactory<IPlayerState> _stateFactory;
    protected List<IObserver> _observers = new List<IObserver>();
    protected bool _initialized = false;
    protected float _moveSpeed;
    protected float _speedMultiplier;
    protected float _speedMilestoneCount;
    protected float _speedIncreaseMilestone;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IPlayerStateFactory stateFactory object that create other objects, here, IState
     */

    [Inject]
    public virtual void Construct(IPlayerStateFactory<IPlayerState> stateFactory)
    {
        _stateFactory = stateFactory;
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** RIGIBODY2D GETTER/SETTER *****/
    /************************************/

    /**
     * @access public
     */

    public Rigidbody2D Rigidbody
    {
        get { return _rigidbody; }
        set { _rigidbody = value; }
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** ANIMATOR GETTER/SETTER *****/
    /**********************************/

    /**
     * @access public
     */

    public Animator Animator
    {
        get { return _animator; }
        set { _animator = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** STATE GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public IPlayerState State
    {
        get { return _state; }
        set { _state = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** STATE FACTORY GETTER/SETTER *****/
    /***************************************/

    /**
     * @access public
     */

    public IPlayerStateFactory<IPlayerState> StateFactory
    {
        get { return _stateFactory; }
        set { _stateFactory = value; }
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

    /************************************/
    /***** MOVE SPEED GETTER/SETTER *****/
    /************************************/

    /**
     * @access public
     */

    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************************************/
    /***** SPEED MULTIPLIER GETTER/SETTER *****/
    /******************************************/

    /**
     * @access public
     */

    public float SpeedMultiplier
    {
        get { return _speedMultiplier; }
        set { _speedMultiplier = value; }
    }

    /**************************************************/
    /**************************************************/

    /***********************************************/
    /***** SPEED MILESTONE COUNT GETTER/SETTER *****/
    /***********************************************/

    /**
     * @access public
     */

    public float SpeedMilestoneCount
    {
        get { return _speedMilestoneCount; }
        set { _speedMilestoneCount = value; }
    }

    /**************************************************/
    /**************************************************/

    /**************************************************/
    /***** SPEED INCREASE MILESTONE GETTER/SETTER *****/
    /**************************************************/

    /**
     * @access public
     */

    public float SpeedIncreaseMilestone
    {
        get { return _speedIncreaseMilestone; }
        set { _speedIncreaseMilestone = value; }
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

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     */

    public abstract void ObserverUpdate();

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IPLAYER HANDLE INPUT *****/
    /********************************/

    /**
     * @access public
     */

    public abstract void HandleInput();

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** ISTATE SUBJECT UPDATE STATE *****/
    /***************************************/

    /**
     * @access public
     */

    public abstract void UpdateState();

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

    /*********************************/
    /***** ON COLLISION ENTER 2D *****/
    /*********************************/

    /**
     * @access public
     */
  
    public abstract void OnCollisionEnter2D(Collision2D other);
}
