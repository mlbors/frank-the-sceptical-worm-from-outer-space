/**
 * FTSWFOS - ObjectComputerFactory - Concrete Class
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

/***********************************/
/***** OBJECT COMPUTER FACTORY *****/
/***********************************/

public class ObjectComputerFactory : AbstractDIFactory<IObjectComputer>, IObjectComputerFactory<IObjectComputer>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ObjectComputerType _type type of object computer
     */

    protected ObjectComputerType _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param ObjectComputerType type type of object computer
     */

    public ObjectComputerFactory(DiContainer container, ObjectComputerType type = ObjectComputerType.Bonus) : base (container)
    {
        _type = type;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** TYPE GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public ObjectComputerType Type
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
     * @return IObjectComputer
     */

    public override IObjectComputer Create(params object[] constructorArguments)
    {
        IObjectComputer objectComputer;

        switch (_type)
        {
            case ObjectComputerType.Back:
                objectComputer = _container.Instantiate<BackComputer>() as IObjectComputer;
                break;
            case ObjectComputerType.Bonus:
                objectComputer = _container.Instantiate<BonusComputer>() as IObjectComputer;
                break;
            case ObjectComputerType.Death:
                objectComputer = _container.Instantiate<DeathComputer>() as IObjectComputer;
                break;
            case ObjectComputerType.Front:
                objectComputer = _container.Instantiate<FrontComputer>() as IObjectComputer;
                break;
            case ObjectComputerType.Middle:
                objectComputer = _container.Instantiate<MiddleComputer>() as IObjectComputer;
                break;
            case ObjectComputerType.NegativeBonus:
                objectComputer = _container.Instantiate<NegativeBonusComputer>() as IObjectComputer;
                break;
            case ObjectComputerType.PowerUp:
                objectComputer = _container.Instantiate<PowerUpComputer>() as IObjectComputer;
                break;
            case ObjectComputerType.Spike:
                objectComputer = _container.Instantiate<SpikeComputer>() as IObjectComputer;
                break;
            default:
                objectComputer = _container.Instantiate<BonusComputer>() as IObjectComputer;
                break;
        }

        return objectComputer;
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
        _container.Instantiate<BackComputer>();
        _container.Instantiate<BonusComputer>();
        _container.Instantiate<DeathComputer>();
        _container.Instantiate<FrontComputer>();
        _container.Instantiate<MiddleComputer>();
        _container.Instantiate<NegativeBonusComputer>();
        _container.Instantiate<PowerUpComputer>();
        _container.Instantiate<SpikeComputer>();
    }
}