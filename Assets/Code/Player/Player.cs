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
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param GameObject gameObject player's game object
     * @param IFactory stateFactory object that create other objects, here, IState
     */

    [Inject]
    public override void Construct(GameObject gameObject, IFactory stateFactory)
    {
        base.Construct(gameObject, stateFactory);
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