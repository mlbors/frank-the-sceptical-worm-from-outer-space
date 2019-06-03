/**
 * FTSWFOS - ICamera - Interface
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

/*******************/
/***** ICAMERA *****/
/*******************/

public interface ICamera
{
    ICameraTarget CameraTarget
    {
        get;
        set;
    }

    bool Resetting
    {
        get;
        set;
    }

    void Reset();
}