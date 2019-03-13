/**
 * FTSWFOS - EnvironmentOperatorElement - Concrete Class
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

/****************************************/
/***** ENVIRONMENT OPERATOR ELEMENT *****/
/****************************************/

public class EnvironmentOperatorElement : AbstractSimpleGeneratorOperatorElement<IEnvironmentObject>, IEnvironmentOperatorElement, IObserver
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @param IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
     * @param IPoolFactory poolFactory factory object that creates other objects, here, IPool
     */

    [Inject]
    public override void Construct(IGeneratorFactory<IGenerator> generatorFactory,
                                   IDestroyerFactory<IDestroyer> destroyerFactory,
                                   IPoolFactory<IPool> poolFactory)
    {
        base.Construct(generatorFactory, destroyerFactory, poolFactory);
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    /**
     * @access public
     */

    public override void Init()
    {
        _SetPool();
        _SetDestroyer();
        _SetGenerator();
        _InitDestroyer();
        _InitGenerator();
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** SET POOL *****/
    /********************/

    /**
     * @access protected
     */

    protected void _SetPool()
    {
        _poolFactory.Type = PoolType.EnvironmentObject;
        Pool = _poolFactory.Create();
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** SET DESTROYER *****/
    /*************************/

    /**
     * @access protected
     */

    protected void _SetDestroyer()
    {
        _destroyerFactory.Type = DestroyerType.EnvironmentObject;
        Destroyer = _destroyerFactory.Create() as IDestroyer<IEnvironmentObject>;
        _destroyer.Pool = _pool as IPool<IEnvironmentObject>;
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** SET GENERATOR *****/
    /*************************/

    /**
     * @access protected
     */

    protected void _SetGenerator()
    {
        _generatorFactory.Type = GeneratorType.EnvironmentObject;
        Generator = _generatorFactory.Create() as IGenerator<IEnvironmentObject>;
        _generator.Pool = _pool as IPool<IEnvironmentObject>;
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** INIT DESTROYER *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _InitDestroyer()
    {
        _destroyer.Init();
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** INIT GENERATOR *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _InitGenerator()
    {
        _generator.Init();
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** OPERATORELEMENT - OPERATE *****/
    /*************************************/

    /**
     * @access public
     */

    public override void Operate()
    {
        if (_generationPoint == null || _destructionPoint == null)
        {
            return;
        }

        CallGenerator();
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     */

    public void ObserverUpdate(string info, object data)
    {
        if (info == "camera inited")
        {
            Generator.ReferenceObject = (data as MonoBehaviour);
            Destroyer.ReferenceObject = (data as MonoBehaviour);
        }

        if (info == "camera created")
        {
            GenerationPoint = (data as List<Transform>)[0];
            DestructionPoint = (data as List<Transform>)[1];
        }
    }

    /**************************************************/
    /**************************************************/

    /******************************************************/
    /***** IGENERATOR OPERATOR ELEMENT CALL GENERATOR *****/
    /******************************************************/

    public override void CallGenerator()
    {
        _generator.Generate();
    }

    /**************************************************/
    /**************************************************/

    /******************************************************/
    /***** IGENERATOR OPERATOR ELEMENT CALL DESTROYER *****/
    /******************************************************/

    public override void CallDestroyer()
    {
        _destroyer.Destroy();
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access public
     */

    public override void Start()
    {

    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /**
     * @access public
     */

    public override void Update()
    {
        Operate();
    }
}