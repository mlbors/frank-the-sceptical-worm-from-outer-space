/**
 * FTSWFOS - AbstractCamera - Abstract Class
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

/***************************/
/***** ABSTRACT CAMERA *****/
/***************************/

abstract public class AbstractCamera : ICamera
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ICameraTarget _cameraTarget camera target
     */

    protected ICameraTarget _target;

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** TARGET GETTER/SETTER *****/
    /********************************/

    /*
     * @access public
     */

    public ICameraTarget CameraTarget
    {
        get { return _target; }
        set { _target = value; }
    }
}
