/**
 * FTSWFOS - AbstractGeneratorOperatorElement - Abstract Class
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

/***********************************************/
/***** ABSTRACT GENERATOR OPERATOR ELEMENT *****/
/***********************************************/

abstract public class AbstractGeneratorOperatorElement<T> : MonoBehaviour, IGeneratorOperatorElement<T>, IOperatorElement, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @var IGenerator _generator object that generates other kind of objects using a pool system
     * @var IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
     * @var IDestroyer _destroyer object that destroys generated object using a pool system
     * @var Transform _generationPoint when to generate objects
     * @var Transform _destructionPoint when to destroy points
     * @var IPool _pool pool object objects
     * @var IPoolFactory _poolFactory factory object that creates other objects, here, IPool
     * @var IOperatorElementFactory<IOperatorElement> _operatorElementFactory object that create other objects, here, IOperatorElementFactory
     */

    protected IGeneratorFactory<IGenerator> _generatorFactory;
    protected IGenerator<T> _generator;
    protected IDestroyerFactory<IDestroyer> _destroyerFactory;
    protected IDestroyer<T> _destroyer;
    protected Transform _generationPoint;
    protected Transform _destructionPoint;
    protected IPool _pool;
    protected IPoolFactory<IPool> _poolFactory;
    protected IOperatorElementFactory<IOperatorElement> _operatorElementFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @param IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
     * @param List points list of points
     * @param IOperatorElementFactory<IOperatorElement> operatorElementFactory object that create other objects, here, IOperatorElementFactory
     */

    [Inject]
    public virtual void Construct(IGeneratorFactory<IGenerator> generatorFactory, 
                                  IDestroyerFactory<IDestroyer> destroyerFactory,
                                  IPoolFactory<IPool> poolFactory,
                                  IOperatorElementFactory<IOperatorElement> operatorElementFactory)
    {
        _SetValues(generatorFactory, destroyerFactory, poolFactory, operatorElementFactory);
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
     * @param IPoolFactory _poolFactory factory object that creates other objects, here, IPool
     * @param IOperatorElementFactory<IOperatorElement> operatorElementFactory object that create other objects, here, IOperatorElementFactory
     */

    protected void _SetValues(IGeneratorFactory<IGenerator> generatorFactory,
                              IDestroyerFactory<IDestroyer> destroyerFactory,
                              IPoolFactory<IPool> poolFactory,
                              IOperatorElementFactory<IOperatorElement> operatorElementFactory)
    {
        GeneratorFactory = generatorFactory;
        DestroyerFactory = destroyerFactory;
        PoolFactory = poolFactory;
        OperatorElementFactory = operatorElementFactory;
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

    /**************************************************/
    /***** OPERATOR ELEMENT FACTORY GETTER/SETTER *****/
    /**************************************************/

    /**
     * @access public
     */

    public IOperatorElementFactory<IOperatorElement> OperatorElementFactory
    {
        get { return _operatorElementFactory; }
        set { _operatorElementFactory = value; }
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

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access public
     */

    public abstract void Start();

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /**
     * @access public
     */

    public abstract void Update();
}
