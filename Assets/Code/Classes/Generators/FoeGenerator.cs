/**
 * FTSWFOS - FoeGenerator - Concrete Class
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

/*************************/
/***** FOE GENERATOR *****/
/*************************/

public class FoeGenerator : AbstractGenerator<IFoe>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IPoolFactory _poolFactory factory object that creates other objects, here, IPool
     */

    public FoeGenerator() : base()
    {
    }

    /**************************************************/
    /**************************************************/

    /****************/
    /***** INIT *****/
    /****************/

    /**
     * @access public
     */

    public override void Init()
    {

    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public override void Generate()
    {

    }
}
