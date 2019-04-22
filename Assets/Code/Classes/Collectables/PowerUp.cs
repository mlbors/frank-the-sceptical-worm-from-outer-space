/**
 * FTSWFOS - PowerUp - Concrete Class
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

/********************/
/***** POWER UP *****/
/********************/

public class PowerUp : AbstractCollectable
{
    /********************************/
    /***** ICOLLECTABLE PERFORM *****/
    /********************************/

    /**
     * @access public
     */

    public override void Perform()
    {
        Notify(ObservableEventType.BonusHitten, 10);
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** ISOUNDING OBJECT PLAY SOUND *****/
    /***************************************/

    /**
     * @access public
     */

    public override void PlaySound()
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
        base.OnTriggerEnter2D(otherObject);
    }
}
 