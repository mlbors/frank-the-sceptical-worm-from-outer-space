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

public class GameLoader : AbstractLoader, IGameLoader, IInitializable
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
        base.Construct(managerFactory);
        _SetValues();
        InitManagers();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    void _SetValues()
    {
        _managerFactory.Type = ManagerTypes.GameManager;
        IManager gameManager = _managerFactory.Create();
        AddManager(gameManager);
    }

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
        foreach(IManager manager in _managers) 
        {
            Debug.Log("::: Init Manager :::");
            Debug.Log("::: Manager object :::");
            Debug.Log(manager);
            manager.Init();
        }
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