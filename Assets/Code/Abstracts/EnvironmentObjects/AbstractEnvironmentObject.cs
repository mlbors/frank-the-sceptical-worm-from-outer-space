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
     */

    protected EnvironmentObjectType _type;
    protected MonoBehaviour _followedObject;

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
}
 