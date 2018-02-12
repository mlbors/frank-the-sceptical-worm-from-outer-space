/**
 * FTSWFOS - AbstractGenerator - Abstract Class
 *
 * @since       09.01.2018
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

/******************************/
/***** ABSTRACT GENERATOR *****/
/******************************/

abstract public class AbstractGenerator : IGenerator
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IPool _pool objects pool
     */

    private IPool _pool;

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** POOL GETTER/SETTER *****/
    /******************************/

    public IPool Pool
    {
        get { return _pool; }
        set { _pool = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public abstract void Generate();
}
