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
     * @var Rigibody2D _rigibody player rigidbody
     * @var Animator _animator player animator
     */

    protected Rigidbody2D _rigidbody;
    protected Animator _animator;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    [Inject]
    public override void Construct()
    {

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

    protected void _InitPlayer()
    {
        Debug.Log("::: init player :::");

        _GetComponents();

        transform.position = new Vector3(0, 0, transform.position.z);

        _stateFactory.Subject = this;
        _stateFactory.Type = PlayerStates.Running;
        State = _stateFactory.Create();
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
        _InitPlayer();
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