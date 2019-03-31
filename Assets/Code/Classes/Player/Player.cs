﻿/**
 * FTSWFOS - Player - Concrete Class
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

/******************/
/***** PLAYER *****/
/******************/

public class Player : AbstractPlayer
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Stack _statesStack a stack containing player states
     * @var Dictionary _statesPool a dictionary used as a pool for player states
     * @var LayerMask _ground what defines the ground
     * @var Transform _groundChecker what can check if player is grounded
     */

    protected Stack<IPlayerState> _statesStack = new Stack<IPlayerState>();
    protected Dictionary<PlayerState, IPlayerState> _statesPool = new Dictionary<PlayerState, IPlayerState>();
    protected LayerMask _ground;
    protected Transform _groundChecker;

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
    public override void Construct(IPlayerStateFactory<IPlayerState> stateFactory)
    {
        base.Construct(stateFactory);
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** GET COMPONENTS *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _GetComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    /**************************************************/
    /**************************************************/

    /***********************/
    /***** INIT PLAYER *****/
    /***********************/

    /**
     * @access protected
     */

    protected bool _InitPlayer()
    {
        try
        {
            if (_stateFactory == null)
            {
                _initialized = false;
                return _initialized;
            }

            _GetComponents();

            _moveSpeed = 6.75f;
            _speedMultiplier = 1.25f;
            _speedMilestoneCount = 0.00f;
            _speedIncreaseMilestone = 80.25f;

            _ground = LayerMask.GetMask("Ground");
            _groundChecker = this.transform.Find("GroundCheck");

            _stateFactory.Subject = this as IPlayerStateSubject;

            _initialized = true;

            transform.position = new Vector3(0, 0, transform.position.z);

            ChangeState(PlayerState.Standing);

            return _initialized;
        }
        catch (Exception e)
        {
            Debug.Log($"Exception thrown: {e.Message}");
            return false;
        }
    }

    /**************************************************/
    /**************************************************/

    /************************/
    /***** CHANGE STATE *****/
    /************************/

    /**
     * @access protected
     * @param PlayerState state desired state
     */

    public override void ChangeState(PlayerState state)
    {
        if (!_initialized)
        {
            return;    
        }

        IPlayerState newState = _CreatePlayerState(state);
        _statesStack.Push(newState);
        _LeaveState();
        State = newState;
        _state.Enter();
        return;
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** CREATE PLAYER STATE *****/
    /*******************************/

    /**
     * @access protected
     * @param PlayerState state desired state
     */

    protected IPlayerState _CreatePlayerState(PlayerState state)
    {
        IPlayerState newState;

        if (_statesPool.ContainsKey(state))
        {
            newState = _GetStateFromPool(state);
            return newState;
        } 
 
        newState = _GetStateFromFactory(state);
        _statesPool[state] = newState;
        return newState;
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** GET STATE FROM POOL *****/
    /*******************************/

    /**
     * @access protected
     * @param PlayerState state desired state
     */

    protected IPlayerState _GetStateFromPool(PlayerState state)
    {
        return _statesPool[state];
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** GET STATE FROM FACTORY *****/
    /**********************************/

    /**
     * @access protected
     * @param PlayerState state desired state
     */

    protected IPlayerState _GetStateFromFactory(PlayerState state)
    {
        _stateFactory.Type = state;
        return _stateFactory.Create();
    }

    /**************************************************/
    /**************************************************/

    /***********************/
    /***** LEAVE STATE *****/
    /***********************/

    protected void _LeaveState()
    {
        if (State != null)
        {
            State.Leave();
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     * @param String info info for update
     */

    public override void ObserverUpdate(ObservableEventType info, object data)
    {
        
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IPLAYER HANDLE INPUT *****/
    /********************************/

    /**
     * @access public
     */

    public override void HandleInput()
    {
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** ISTATE SUBJECT UPDATE STATE *****/
    /***************************************/

    /**
     * @access public
     */

    public override void UpdateState()
    {
        _state.Update();

        if ((_state.Name == "Jumping" || _state.Name == "DoubleJumping") && _state.CanBeLeft && _CheckIfGrounded())
        {
            ChangeState(PlayerState.Running);
            return;
        }
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** AWAKE *****/
    /*****************/

    /**
     * @access public
     */

    public override void Awake()
    {
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
        if (!_initialized)
        {
            _InitPlayer();
            return;
        }
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
        if (_state.Name == "Standing")
        {
            ChangeState(PlayerState.Running);
        }
        HandleInput();
        UpdateState();
    }

    /**************************************************/
    /**************************************************/

    /*****************************/
    /***** CHECK IF GROUNDED *****/
    /*****************************/

    /**
     * @access protected
     * @return bool
     */

    protected bool _CheckIfGrounded()
    {
        if (Physics2D.OverlapCircle(_groundChecker.position, 0.015f, _ground))
        {
            Notify(ObservableEventType.PlayerGrounded, null);
            return true;
        }

        return false;
    }

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** ON COLLISION ENTER 2D *****/
    /*********************************/

    /**
     * @access public
     */

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground" && other.otherCollider.GetType() == typeof(CircleCollider2D))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<CircleCollider2D>());
        }
    }
}