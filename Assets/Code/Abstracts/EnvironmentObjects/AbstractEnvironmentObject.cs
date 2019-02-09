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
     */

    protected EnvironmentObjectType _type;

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
}
 