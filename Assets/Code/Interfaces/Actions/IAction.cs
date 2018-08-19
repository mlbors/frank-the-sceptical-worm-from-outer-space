/**
 * FTSWFOS - IAction - Interface
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
using System.Runtime.InteropServices;
using UnityEngine;

/**************************************************/
/**************************************************/

/*******************/
/***** IACTION *****/
/*******************/

public interface IAction
{
    void Perform([Optional] ICommandSubject subject);
}