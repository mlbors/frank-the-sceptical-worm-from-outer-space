/**
 * FTSWFOS - AbstractCamera - Abstract Class
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

/***************************/
/***** ABSTRACT CAMERA *****/
/***************************/

abstract public class AbstractCamera : MonoBehaviour, ICamera, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ICameraTarget _cameraTarget camera target
     * @var Bool _initialized tells if camerea is initialized
     */

    protected ICameraTarget _cameraTarget;
    protected bool _initialized = false;
    protected bool _resetting = false;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param ICameraTarget cameraTarget camera's target
     */

    [Inject]
    public virtual void Construct()
    {
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** CAMERA TARGET GETTER/SETTER *****/
    /***************************************/

    /**
     * @access public
     */

    public ICameraTarget CameraTarget
    {
        get { return _cameraTarget; }
        set { _cameraTarget = value; }
    }

    /**************************************************/
    /**************************************************/

    /***********************************/
    /***** RESETTING GETTER/SETTER *****/
    /***********************************/

    /**
     * @access public
     */

    public bool Resetting
    {
        get { return _resetting; }
        set { _resetting = value; }
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** RESET *****/
    /*****************/

    /**
     * @access public
     */

    public virtual void Reset()
    {
        transform.position = new Vector3(0.00f, 0.00f, transform.position.z);
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
