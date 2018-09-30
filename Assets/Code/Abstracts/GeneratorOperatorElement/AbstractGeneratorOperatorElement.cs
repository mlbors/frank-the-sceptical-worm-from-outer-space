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
     * @var IGenerator _generator object that generates other kind of objects using a pool system
     * @var IDestroyer _destroyer object that destroys generated object using a pool system
     * @var GameObject _generatorPoint when to generate objects
     * @var GameObject _destroyerPoint when to destroy points
     */

    protected IGenerator<T> _generator;
    protected IDestroyer<T> _destroyer;
    protected GameObject _generatorPoint;
    protected GameObject _destroyerPoint;

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

    /*****************************************/
    /***** GENERATOR POINT GETTER/SETTER *****/
    /*****************************************/

    /**
     * @access public
     */

    public GameObject GeneratorPoint
    {
        get { return _generatorPoint; }
        set { _generatorPoint = value; }
    }

    /**************************************************/
    /**************************************************/

    /*****************************************/
    /***** DESTROYER POINT GETTER/SETTER *****/
    /*****************************************/

    /**
     * @access public
     */

    public GameObject DestroyerPoint
    {
        get { return _destroyerPoint; }
        set { _destroyerPoint = value; }
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
}
