﻿/**
 * FTSWFOS - OperatorFactory - Concrete Class
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

/****************************/
/***** OPERATOR FACTORY *****/
/****************************/

public class OperatorFactory : AbstractDIFactory<IOperator>, IOperatorFactory<IOperator>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var OperatorTypes _type type of operator
     */

    protected OperatorTypes _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param OperatorTypes type type of command
     */

    public OperatorFactory(DiContainer container, OperatorTypes type = OperatorTypes.GameOperator) : base (container)
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

    public OperatorTypes Type
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
     * @return IOperator
     */

    public override IOperator Create(params object[] constructorArguments)
    {
        IOperator theOperator;

        switch (_type)
        {
            case OperatorTypes.GameOperator:
                theOperator = _container.Instantiate<GameOperator>() as IOperator;
                break;
            default:
                theOperator = _container.Instantiate<GameOperator>() as IOperator;
                break;
        }

        Debug.Log("::: operator created :::");
        return theOperator;
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
        _container.Instantiate<GameOperator>();
    }
}