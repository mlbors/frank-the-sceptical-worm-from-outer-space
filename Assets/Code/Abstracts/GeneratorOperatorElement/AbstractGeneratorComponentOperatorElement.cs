/**
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

/***********************************************/
/***** ABSTRACT GENERATOR COMPONENT OPERATOR ELEMENT *****/
/***********************************************/

abstract public class AbstractGeneratorComponentOperatorElement<T> : IGeneratorComponentOperatorElement<T>, IOperatorElement, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @var IGenerator _generator object that generates other kind of objects using a pool system
     * @var IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
     * @var IDestroyer _destroyer object that destroys generated object using a pool system
     */

    protected IGeneratorFactory<IGenerator> _generatorFactory;
    protected IGenerator<T> _generator;
    protected IDestroyerFactory<IDestroyer> _destroyerFactory;
    protected IDestroyer<T> _destroyer;

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
                                  IDestroyerFactory<IDestroyer> destroyerFactory)
    {
        _SetValues(generatorFactory, destroyerFactory);
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
                              IDestroyerFactory<IDestroyer> destroyerFactory)
    {
        GeneratorFactory = generatorFactory;
        DestroyerFactory = destroyerFactory;
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
