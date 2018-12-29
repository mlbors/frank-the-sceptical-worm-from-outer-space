/**
 * FTSWFOS - SpikeComputer - Concrete Class
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

/**************************/
/***** SPIKE COMPUTER *****/
/**************************/

public class SpikeComputer : AbstractObjectComputer<IFoe>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     */

    public SpikeComputer()
    {
    }

    /**************************************************/
    /**************************************************/

    /************************************************/
    /***** IOBJECT COMPUTER EXECUTE COMPUTATION *****/
    /************************************************/

    /**
     * @access public
     */

    public override Vector3 ExecuteComputation()
    {
        return new Vector3();
    }
}
