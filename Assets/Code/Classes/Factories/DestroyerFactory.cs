/**
 * FTSWFOS - DestroyerFactory - Concrete Class
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

/*****************************/
/***** DESTROYER FACTORY *****/
/*****************************/

public class DestroyerFactory : AbstractDIFactory<IDestroyer>, IDestroyerFactory<IDestroyer>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var DestroyerType _type type of generator
     */

    protected DestroyerType _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param DestroyerType _ype type of generator
     */

    public DestroyerFactory(DiContainer container, DestroyerType type = DestroyerType.Platform) : base (container)
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

    public DestroyerType Type
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
     * @return IDestroyer
     */

    public override IDestroyer Create(params object[] constructorArguments)
    {
        IDestroyer destroyer;

        switch (_type)
        {
            case DestroyerType.Collectable:
                destroyer = _container.Instantiate<CollectableDestroyer>() as IDestroyer;
                break;
            case DestroyerType.Foe:
                destroyer = _container.Instantiate<FoeDestroyer>() as IDestroyer;
                break;
            case DestroyerType.Platform:
                destroyer = _container.Instantiate<PlatformDestroyer>() as IDestroyer;
                break;
            default:
                destroyer = _container.Instantiate<PlatformDestroyer>() as IDestroyer;
                break;
        }

        return destroyer;
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
        _container.Instantiate<CollectableDestroyer>();
        _container.Instantiate<FoeDestroyer>();
        _container.Instantiate<PlatformDestroyer>();
    }
}