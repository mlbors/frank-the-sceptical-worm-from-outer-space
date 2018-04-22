/**
 * FTSWFOS - AbstractDestroyer - Abstract Class
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
/***** ABSTRACT DESTROYER *****/
/******************************/

abstract public class AbstractDestroyer : IDestroyer
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IPool _pool objects pool
     */

    protected IPool _pool;

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

    /*******************/
    /***** DESTROY *****/
    /*******************/

    public abstract void Destroy();
}
