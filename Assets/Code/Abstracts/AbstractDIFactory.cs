/**
 * FTSWFOS - AbstractDIFactory - Abstract Class
 *
 * @since       09.01.2018
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

abstract public class AbstractDIFactory : AbstractFactory, IValidatable
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
     * @return object of type T where T is a class, inherits from K and can be instantiated
     */

    public override T Create<T, K>(params object[] constructorArguments)
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