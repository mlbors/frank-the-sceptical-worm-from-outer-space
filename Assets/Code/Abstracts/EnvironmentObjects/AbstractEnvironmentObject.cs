/**
 * FTSWFOS - AbstractEnvironmentObject - Abstract Class
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

/***************************************/
/***** ABSTRACT ENVIRONMENT OBJECT *****/
/***************************************/

abstract public class AbstractEnvironmentObject : MonoBehaviour, IEnvironmentObject, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var EnvironmentObjectType _type type of environment object
     * @var MonoBehaviour _followedObject object to follow (position)
     * @var float _x x position
     * @var float _y y position
     * @var float _z z position    
     */

    protected EnvironmentObjectType _type;
    protected MonoBehaviour _followedObject;
    protected float _x;
    protected float _y;
    protected float _z;

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** TYPE GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public EnvironmentObjectType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    /**************************************************/
    /**************************************************/

    /*****************************************/
    /***** FOLLOWED OBJECT GETTER/SETTER *****/
    /*****************************************/

    /**
     * @access public
     */

    public MonoBehaviour FollowedObject
    {
        get { return _followedObject; }
        set { _followedObject = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** X GETTER/SETTER *****/
    /***************************/

    /**
     * @access public
     */

    public float X
    {
        get { return _x; }
        set { _x = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** Y GETTER/SETTER *****/
    /***************************/

    /**
     * @access public
     */

    public float Y
    {
        get { return _y; }
        set { _y = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************/
    /***** Z GETTER/SETTER *****/
    /***************************/

    /**
     * @access public
     */

    public float Z
    {
        get { return _z; }
        set { _z = value; }
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** AWAKE *****/
    /*****************/

    /**
     * @access public
     */

    public abstract void Awake();

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
 