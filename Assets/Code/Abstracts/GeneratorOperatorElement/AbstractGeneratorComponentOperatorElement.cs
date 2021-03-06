﻿/**
 * FTSWFOS - AbstractGeneratorComponentOperatorElement - Abstract Class
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

/*********************************************************/
/***** ABSTRACT GENERATOR COMPONENT OPERATOR ELEMENT *****/
/*********************************************************/

abstract public class AbstractGeneratorComponentOperatorElement<T> : IGeneratorComponentOperatorElement<T>, IGeneratorOperatorElement<T>, IOperatorElement, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var MonoBehaviour _referenceObject object used as a reference
     * @var @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @var IGenerator _generator object that generates other kind of objects using a pool system
     * @var IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
     * @var IDestroyer _destroyer object that destroys generated object using a pool system
     * @var Transform _generationPoint when to generate objects
     * @var Transform _destructionPoint when to destroy points
     * @var IPool _pool pool object objects
     * @var IPoolFactory _poolFactory factory object that creates other objects, here, IPool
     * @var String _requiredAction action too execute
     */

    protected MonoBehaviour _referenceObject;
    protected IGeneratorFactory<IGenerator> _generatorFactory;
    protected IGenerator<T> _generator;
    protected IDestroyerFactory<IDestroyer> _destroyerFactory;
    protected IDestroyer<T> _destroyer;
    protected Transform _generationPoint;
    protected Transform _destructionPoint;
    protected IPool _pool;
    protected IPoolFactory<IPool> _poolFactory;
    protected string _requiredAction;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @param IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
     */

    [Inject]
    public virtual void Construct(IGeneratorFactory<IGenerator> generatorFactory, 
                                  IDestroyerFactory<IDestroyer> destroyerFactory,
                                  IPoolFactory<IPool> poolFactory)
    {
        _SetValues(generatorFactory, destroyerFactory, poolFactory);
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    /**
     * @access public
     * @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @param IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
     * @param List points list of points
     */

    protected void _SetValues(IGeneratorFactory<IGenerator> generatorFactory,
                              IDestroyerFactory<IDestroyer> destroyerFactory,
                              IPoolFactory<IPool> poolFactory)
    {
        GeneratorFactory = generatorFactory;
        DestroyerFactory = destroyerFactory;
        PoolFactory = poolFactory;
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** GENERATOR FACTORY GETTER/SETTER *****/
    /*******************************************/

    /**
     * @access public
     */

    public IGeneratorFactory<IGenerator> GeneratorFactory
    {
        get { return _generatorFactory; }
        set { _generatorFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /***********************************/
    /***** GENERATOR GETTER/SETTER *****/
    /***********************************/

    /**
     * @access public
     */

    public IGenerator<T> Generator
    {
        get { return _generator; }
        set { _generator = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** DESTROYER FACTORY GETTER/SETTER *****/
    /*******************************************/

    /**
     * @access public
     */

    public IDestroyerFactory<IDestroyer> DestroyerFactory
    {
        get { return _destroyerFactory; }
        set { _destroyerFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /***********************************/
    /***** DESTROYER GETTER/SETTER *****/
    /***********************************/

    /**
     * @access public
     */

    public IDestroyer<T> Destroyer
    {
        get { return _destroyer; }
        set { _destroyer = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** POOL GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public IPool Pool
    {
        get { return _pool; }
        set { _pool = value; }
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** POOL FACTORY GETTER/SETTER *****/
    /**************************************/

    /**
     * @access public
     */

    public IPoolFactory<IPool> PoolFactory
    {
        get { return _poolFactory; }
        set { _poolFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************************************/
    /***** REFERENCE OBJECT GETTER/SETTER *****/
    /******************************************/

    /**
     * @access public
     */

    public MonoBehaviour ReferenceObject
    {
        get { return _referenceObject; }
        set { _referenceObject = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************************************/
    /***** GENERATION POINT GETTER/SETTER *****/
    /******************************************/

    /**
     * @access public
     */

    public Transform GenerationPoint
    {
        get { return _generationPoint; }
        set { _generationPoint = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** DESTRUCTION POINT GETTER/SETTER *****/
    /*******************************************/

    /**
     * @access public
     */

    public Transform DestructionPoint
    {
        get { return _destructionPoint; }
        set { _destructionPoint = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** REQUIRED ACTION *****/
    /***************************/

    /**
     * @access public
     */

    public string RequiredAction
    {
        get { return _requiredAction; }
        set { _requiredAction = value; }
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** IOPERATOR ELEMENT INIT *****/
    /**********************************/

    public abstract void Init();

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** IOPERATOR ELEMENT OPERATE *****/
    /*************************************/

    public abstract void Operate();

    /**************************************************/
    /**************************************************/

    /******************************************************/
    /***** IGENERATOR OPERATOR ELEMENT CALL GENERATOR *****/
    /******************************************************/

    public abstract void CallGenerator();

    /**************************************************/
    /**************************************************/

    /******************************************************/
    /***** IGENERATOR OPERATOR ELEMENT CALL DESTROYER *****/
    /******************************************************/

    public abstract void CallDestroyer();
}
