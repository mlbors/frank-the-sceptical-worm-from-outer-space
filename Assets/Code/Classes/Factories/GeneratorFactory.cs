/**
 * FTSWFOS - GeneratorFactory - Concrete Class
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
/***** GENERATOR FACTORY *****/
/*****************************/

public class GeneratorFactory : AbstractDIFactory<IGenerator>, IGeneratorFactory<IGenerator>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var GeneratorType _type type of generator
     */

    protected GeneratorType _type;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param GeneratorType _ype type of generator
     */

    public GeneratorFactory(DiContainer container, GeneratorType type = GeneratorType.Platform) : base (container)
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

    public GeneratorType Type
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
     * @return IGenerator
     */

    public override IGenerator Create(params object[] constructorArguments)
    {
        IGenerator generator;

        switch (_type)
        {
            case GeneratorType.Collectable:
                generator = _container.Instantiate<CollectableGenerator>() as IGenerator;
                break;
            case GeneratorType.EnvironmentObject:
                generator = _container.Instantiate<EnvironmentObjectGenerator>() as IGenerator;
                break;
            case GeneratorType.Foe:
                generator = _container.Instantiate<FoeGenerator>() as IGenerator;
                break;
            case GeneratorType.Platform:
                generator = _container.Instantiate<PlatformGenerator>() as IGenerator;
                break;
            default:
                generator = _container.Instantiate<PlatformGenerator>() as IGenerator;
                break;
        }

        return generator;
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
        _container.Instantiate<CollectableGenerator>();
        _container.Instantiate<EnvironmentObjectGenerator>();
        _container.Instantiate<FoeGenerator>();
        _container.Instantiate<PlatformGenerator>();
    }
}