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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/**************************************************/
/**************************************************/

/***********************/
/***** GAME LOADER *****/
/***********************/

public class GameLoader : AbstractLoader, IGameLoader
{   
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IManagerFactory managerFactory factory object that creates other objects, here, IManager
     */

    [Inject]
    public override void Construct(IManagerFactory<IManager> managerFactory)
    {
        Debug.Log("::: GameLoader construct :::");
        base.Construct(managerFactory);
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        Debug.Log("::: GameLoader setting values :::");
        _managerFactory.Type = ManagerTypes.GameManager;
        IManager gameManager = _managerFactory.Create();
        AddManager(gameManager);
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
        _SetValues();
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
        InitManagers();
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
        //Debug.Log("::: GameLoader Update :::");
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
        Debug.Log("::: Try to init managers :::");
        foreach(IManager manager in _managers) 
        {
            Debug.Log("::: Init Manager :::");
            Debug.Log("::: Manager object :::");
            Debug.Log(manager);
            manager.Init();
        }
    }
}