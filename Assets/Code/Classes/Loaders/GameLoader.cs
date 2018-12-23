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
        base.Construct(managerFactory);
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        _managerFactory.Type = ManagerType.GameManager;
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
            try
            {
                manager.Init();
            }
            catch (Exception e)
            {
                Debug.Log($"Exception thrown: {e.Message}");
            }
        }
    }
}