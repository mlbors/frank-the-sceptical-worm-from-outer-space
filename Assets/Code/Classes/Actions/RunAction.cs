/**
 * FTSWFOS - RunAction - Concrete Classe
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

/**********************/
/***** RUN ACTION *****/
/**********************/

public class RunAction : IAction
{
    /***************************/
    /***** IACTION EXECUTE *****/
    /***************************/

    /**
     * @access public
     */

    public void Perform([Optional] ICommandSubject subject)
    {
        Debug.Log("Performing action");
        if (subject != null)
        {
            try 
            {
                Vector2 vector = (subject as IPlayer).Rigidbody.velocity;
                float x = vector.x;
                float y = vector.y;
                Debug.Log(x);

                float x2 = x;

                if (x2 == 0) {
                    x2 = 1;
                }

                x2 = x2 * 1.25f;

                (subject as IPlayer).Rigidbody.velocity = new Vector2(x2, y);
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
        }
    }
}