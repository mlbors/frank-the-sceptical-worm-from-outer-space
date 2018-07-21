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

abstract public class AbstractGeneratorOperatorElement<T> : IGeneratorOperatorElement<T>, IOperatorElement, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IGenerator _generator object that generates other kind of objects using a pool system
     * @var IDestroyer _destroyer object that destroys generated object using a pool system
     */

    protected IGenerator<T> _generator;
    protected IDestroyer<T> _destroyer;

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
