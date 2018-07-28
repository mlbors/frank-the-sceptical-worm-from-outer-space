/**
 * FTSWFOS - ManagerFactory - Concrete Class
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

/***************************/
/***** MANAGER FACTORY *****/
/***************************/

public class ManagerFactory : AbstractDIFactory<IManager>, IManagerFactory<IManager>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ManagerTypes _type type of manager
     */

    protected ManagerTypes _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param ManagerTypes type type of command
     */

    public ManagerFactory(DiContainer container, ManagerTypes type = ManagerTypes.GameManager) : base (container)
    {
        _type = type;
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** TYPES GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public ManagerTypes Type
    {
        get { return _type; }
        set { _type = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return IManager
     */

    public override IManager Create(params object[] constructorArguments)
    {
        IManager manager;

        switch (_type)
        {
            case ManagerTypes.GameManager:
                manager = _container.Instantiate<GameManager>() as IManager;
                break;
            default:
                manager = _container.Instantiate<GameManager>() as IManager;
                break;
        }

        return manager;
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** IVALIDATABLE VALIDATABLE *****/
    /************************************/

    /**
     * @access public
     */

    public override void Validate()
    {
        _container.Instantiate<GameManager>();
    }
}