/**
 * FTSWFOS - CollectableGenerator - Concrete Class
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
/***** COLLECTABLE GENERATOR *****/
/*********************************/

public class CollectableGenerator : AbstractGenerator<ICollectable>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IPoolFactory _poolFactory factory object that creates other objects, here, IPool
     */

    public CollectableGenerator(IPoolFactory<IPool> poolFactory) : base(poolFactory)
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
