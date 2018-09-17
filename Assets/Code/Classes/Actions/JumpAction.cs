/**
 * FTSWFOS - JumpAction - Concrete Classe
 *
 * @since       2018.01.09
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/**************************************************/
/**************************************************/

/***********************/
/***** JUMP ACTION *****/
/***********************/

public class JumpAction : IAction
{
    /***************************/
    /***** IACTION EXECUTE *****/
    /***************************/

    /**
     * @access public
     */

    public void Perform([Optional] ICommandSubject subject)
    {
        if (subject != null)
        {
            try
            {
                Vector2 velocity = (subject as IPlayer).Rigidbody.velocity;
                (subject as IPlayer).Rigidbody.velocity = new Vector2(velocity.x, 18.55f);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }
}