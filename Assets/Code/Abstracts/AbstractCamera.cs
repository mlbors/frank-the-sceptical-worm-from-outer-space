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

/**************************************************/
/**************************************************/

/***************************/
/***** ABSTRACT CAMERA *****/
/***************************/

abstract public class AbstractCamera : ICamera, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ICameraTarget _cameraTarget camera target
     */

    protected ICameraTarget _cameraTarget;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param ICameraTarget cameraTarget camera's target
     */

    protected AbstractCamera(ICameraTarget cameraTarget)
    {
        _cameraTarget = cameraTarget;
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
}
