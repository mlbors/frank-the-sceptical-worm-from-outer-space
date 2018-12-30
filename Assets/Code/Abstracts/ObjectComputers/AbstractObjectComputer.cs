/**
 * FTSWFOS - AbstractObjectComputer - Abstract Class
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

/************************************/
/***** ABSTRACT OBJECT COMPUTER *****/
/************************************/

abstract public class AbstractObjectComputer<T> : IObjectComputer<T>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var PlatformType _platformType platfrom type used for computation
     * @var Stack<T> _generatedObjects stack of generated objects
     * @var T _currentObject current object used for computation
     * @var IPool _pool objects pool
     * @var MonoBehaviour _referenceObject object used as a reference
     */

    protected PlatformType _platformType;
    protected Stack<T> _generatedObjects = new Stack<T>();
    protected T _currentObject;
    protected IPool<T> _pool;
    protected MonoBehaviour _referenceObject;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     */

    protected AbstractObjectComputer()
    {
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** PLATEFORM TYPE GETTER/SETTER *****/
    /****************************************/

    /**
     * @access public
     */

    public PlatformType PlatformType
    {
        get { return _platformType; }
        set { _platformType = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** GENERATED OBEJCTS GETTER/SETTER *****/
    /*******************************************/

    /**
     * @access public
     */

    public Stack<T> GeneratedObjects
    {
        get { return _generatedObjects; }
        set { _generatedObjects = value; }
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** CURRENT OBJECT GETTER/SETTER *****/
    /****************************************/

    /**
     * @access public
     */

    public T CurrentObject
    {
        get { return _currentObject; }
        set { _currentObject = value; }
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

    /************************************************/
    /***** IOBJECT COMPUTER EXECUTE COMPUTATION *****/
    /************************************************/

    /**
     * @access public
     */

    public abstract void ExecuteComputation();
}
