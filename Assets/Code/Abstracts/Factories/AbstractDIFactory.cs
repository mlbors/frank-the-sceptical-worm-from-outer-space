/**
 * FTSWFOS - AbstractDIFactory - Abstract Class
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

/*******************************/
/***** ABSTRACT DI FACTORY *****/
/*******************************/

abstract public class AbstractDIFactory<T> : AbstractFactory<T>, IValidatable
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Container _container DI container
     */

    protected DiContainer _container;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param DiContainer container DI container
     */

    protected AbstractDIFactory(DiContainer container)
    {
        _container = container;
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     */

    public override T Create (params object[] constructorArguments)
    {
        return _container.Instantiate<T>();
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** IVALIDATABLE VALIDATABLE *****/
    /************************************/

    /**
     * @access public
     */

    public abstract void Validate();
}