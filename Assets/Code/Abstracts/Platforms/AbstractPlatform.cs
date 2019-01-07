/**
 * FTSWFOS - AbstractPlatform - Abstract Class
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

/*****************************/
/***** ABSTRACT PLATFORM *****/
/*****************************/

abstract public class AbstractPlatform : MonoBehaviour, IPlatform, IProduct, IRenderable
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var PlatformType _type platform type
     * @var Float _x x position
     * @var Float _y y position;
     */

    protected PlatformType _type;
    protected float _x;
    protected float _y;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    [Inject]
    public virtual void Construct()
    {
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** TYPE GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public PlatformType Type
    {
        get { return _type; }
        set { _type = value; }
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

    /********************************/
    /***** IRENDERABLE - RENDER *****/
    /********************************/

    /**
     * @access public
     */

    public abstract void Render();

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ON TRIGGER ENTER 2D *****/
    /*******************************/

    /**
     * @access private
     */

    public abstract void OnTriggerEnter2D(Collider2D otherObject);
}
 