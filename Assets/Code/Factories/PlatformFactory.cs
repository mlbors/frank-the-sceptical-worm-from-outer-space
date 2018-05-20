/**
 * FTSWFOS - PlatformFactory - Concrete Class
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

/****************************/
/***** PLATFORM FACTORY *****/
/****************************/

public class PlatformFactory : AbstractDIFactory<IPlatform>, IPlatformFactory<IPlatform>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var PlatformTypes _type type of platform
     */

    protected PlatformTypes _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param PlatformTypes type type of platform
     */

    public PlatformFactory(DiContainer container, PlatformTypes type) : base (container)
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

    public PlatformTypes Type
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
     * @return IPlatform
     */

    public override IPlatform Create(params object[] constructorArguments)
    {
        IPlatform platform;

        switch (_type)
        {
            case PlatformTypes.One:
                break;
            case PlatformTypes.Two:
                break;
            case PlatformTypes.Four:
                break;
            case PlatformTypes.Five:
                break;
            case PlatformTypes.Seven:
                break;
            case PlatformTypes.Nine:
                break;
            default:
                break;
        }

        return platform;
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

    }
}