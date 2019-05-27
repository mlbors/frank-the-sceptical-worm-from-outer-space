/**
 * FTSWFOS - Spike - Concrete Class
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

/*****************/
/***** SPIKE *****/
/*****************/

public class Spike : AbstractFoe
{
    /*********************/
    /***** IFOE LIVE *****/
    /*********************/

    /**
     * @access public
     */

    public override void Live()
    {

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
            Notify(ObservableEventType.SpikeHitten, 5);
        }
    }
}
 