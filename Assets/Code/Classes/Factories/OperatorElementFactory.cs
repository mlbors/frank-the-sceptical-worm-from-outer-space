/**
 * FTSWFOS - OperatorELementFactory - Concrete Class
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

/************************************/
/***** OPERATOR ELEMENT FACTORY *****/
/************************************/

public class OperatorElementFactory : AbstractDIFactory<IOperatorElement>, IOperatorElementFactory<IOperatorElement>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var OperatorElementTypes _type type of operator element
     */

    protected OperatorElementTypes _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param OperatorElementTypes type type of command
     */

    public OperatorElementFactory(DiContainer container, OperatorElementTypes type = OperatorElementTypes.PlayerOperatorElement) : base (container)
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

    public OperatorElementTypes Type
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
     * @return IOperatorElement
     */

    public override IOperatorElement Create(params object[] constructorArguments)
    {
        IOperatorElement operatorElement;

        switch (_type)
        {
            case OperatorElementTypes.CameraOperatorElement:
                operatorElement = _container.Instantiate<CameraOperatorElement>() as IOperatorElement;
                break;
            case OperatorElementTypes.CollectableOperatorElement:
                operatorElement = _container.Instantiate<CollectableOperatorElement>() as IOperatorElement;
                break;
            case OperatorElementTypes.FoeOperatorElement:
                operatorElement = _container.Instantiate<FoeOperatorElement>() as IOperatorElement;
                break;
            case OperatorElementTypes.MenuOperatorElement:
                operatorElement = _container.Instantiate<MenuOperatorElement>() as IOperatorElement;
                break;
            case OperatorElementTypes.PlatformOperatorElement:
                operatorElement = _container.Instantiate<PlatformOperatorElement>() as IOperatorElement;
                break;
            case OperatorElementTypes.PlayerOperatorElement:
                operatorElement = _container.Instantiate<PlayerOperatorElement>() as IOperatorElement;
                break;
            case OperatorElementTypes.ScoreOperatorElement:
                operatorElement = _container.Instantiate<ScoreOperatorElement>() as IOperatorElement;
                break;
            default:
                operatorElement = _container.Instantiate<PlayerOperatorElement>() as IOperatorElement;
                break;
        }

        return operatorElement;
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
        _container.Instantiate<CameraOperatorElement>();
        _container.Instantiate<CollectableOperatorElement>();
        _container.Instantiate<FoeOperatorElement>();
        _container.Instantiate<MenuOperatorElement>();
        _container.Instantiate<PlatformOperatorElement>();
        _container.Instantiate<PlayerOperatorElement>();
        _container.Instantiate< ScoreOperatorElement>();
    }
}