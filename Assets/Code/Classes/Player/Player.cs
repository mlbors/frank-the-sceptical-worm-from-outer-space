/**
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
     */

    protected Stack<IPlayerState> _statesStack = new Stack<IPlayerState>();
    protected Dictionary<PlayerStates, IPlayerState> _statesPool = new Dictionary<PlayerStates, IPlayerState>();

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
        Debug.Log("::: Init player :::");

        if (_stateFactory == null)
        {
            Debug.Log("Can't initialize player now.");
            _initialized = false;
            return _initialized;
        }

        Debug.Log("Initializing player.");

        _GetComponents();

        _moveSpeed = 5.50f;
        _speedMultiplier = 1.75f;
        _speedMilestoneCount = 0.00f;
        _speedIncreaseMilestone = 50.50f;

        _stateFactory.Subject = this as IPlayerStateSubject;

        _initialized = true;

        transform.position = new Vector3(0, 0, transform.position.z);

        ChangeState(PlayerStates.Standing);

        return _initialized;
    }

    /**************************************************/
    /**************************************************/

    /************************/
    /***** CHANGE STATE *****/
    /************************/

    /**
     * @access protected
     * @param PlayerStates state desired state
     */

    public override void ChangeState(PlayerStates state)
    {
        Debug.Log("::: Changing player state :::");

        if (!_initialized)
        {
            return;    
        }

        if (_statesPool.ContainsKey(state)) {
            State = _statesPool[state];
            _statesStack.Push(_state);
            _state.Enter();
            return;
        }

        _stateFactory.Type = state;
        State = _stateFactory.Create();
        _statesStack.Push(_state);
        _statesPool[state] = _state;
        _state.Enter();
        return;
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     */

    public override void ObserverUpdate()
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
        Debug.Log("::: player awake :::");
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
        Debug.Log("::: player start :::");

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
            ChangeState(PlayerStates.Running);
        }
        HandleInput();
        UpdateState();
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
        
    }
}