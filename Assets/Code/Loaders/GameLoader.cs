/**
 * FTSWFOS - GameLoader - Concrete Class
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

/***********************/
/***** GAME LOADER *****/
/***********************/

public class GameLoader : AbstractLoader, IGameLoader, IInitializable
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param GameObject gameObject platform's game object
     */

    [Inject]
    public override void Construct(GameObject gameObject)
    {
        Debug.Log("::: GameLoader Construct :::");
        base.Construct(gameObject);
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** ILOADER AWAKE *****/
    /*************************/

    /**
     * @access public
     */

    public override void Awake()
    {
        Debug.Log("::: GameLoader Awake :::");
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access public
     */

    void Start()
    {
        Debug.Log("::: GameLoader Start :::");
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /**
     * @access public
     */

    void Update()
    {
        Debug.Log("::: GameLoader Update :::");
    }

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** ILOADER INIT MANAGERS *****/
    /*********************************/

    /**
     * @access public
     */

    public override void InitManagers()
    {

    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** ZENJECT INITIALIZE *****/
    /******************************/

    public void Initialize()
    {
        Debug.Log("::: GameLoader Initialize :::");
    }

}