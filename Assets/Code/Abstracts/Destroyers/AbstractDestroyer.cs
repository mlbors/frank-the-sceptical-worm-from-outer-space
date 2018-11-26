/**
 * FTSWFOS - AbstractDestroyer - Abstract Class
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

/******************************/
/***** ABSTRACT DESTROYER *****/
/******************************/

abstract public class AbstractDestroyer<T> : IDestroyer<T>, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var MonoBehaviour _referenceObject object used as a reference
     * @var IPool _pool objects pool
     */

    protected MonoBehaviour _referenceObject;
    protected IPool<T> _pool;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     */

    protected AbstractDestroyer()
    {
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

    /******************************/
    /***** POOL GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public IPool<T> Pool
    {
        get { return _pool; }
        set { _pool = value; }
    }

    /**************************************************/
    /**************************************************/

    /****************/
    /***** INIT *****/
    /****************/

    public abstract void Init();

    /**************************************************/
    /**************************************************/

    /*******************/
    /***** DESTROY *****/
    /*******************/

    public abstract void Destroy();
}
