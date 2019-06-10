/**
 * FTSWFOS - DeathBox - Concrete Class
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

/*********************/
/***** DEATH BOX *****/
/*********************/

public class DeathBox : AbstractDeathBox
{
    /******************************/
    /***** IDEATH BOX OPERATE *****/
    /******************************/

    /**
     * @access public
     */

    public override void Operate()
    {
        Notify(ObservableEventType.DeathHitten, null);
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ON TRIGGER ENTER 2D *****/
    /*******************************/

    /**
     * @access public
     */

    public override void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "Player" && otherObject.GetType() == typeof(BoxCollider2D))
        {
            Operate();
        }
    }
}
 