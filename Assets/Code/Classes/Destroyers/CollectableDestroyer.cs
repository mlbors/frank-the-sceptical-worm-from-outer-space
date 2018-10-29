/**
 * FTSWFOS - CollectableDestroyer - Concrete Class
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

/*********************************/
/***** COLLECTABLE DESTROYER *****/
/*********************************/

public class CollectableDestroyer : AbstractDestroyer<ICollectable>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    public CollectableDestroyer() : base()
    {
    }

    /**************************************************/
    /**************************************************/

    /*******************/
    /***** DESTROY *****/
    /*******************/

    public override void Destroy()
    {

    }
}
