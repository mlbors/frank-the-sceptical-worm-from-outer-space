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

    /*******************/
    /***** DESTROY *****/
    /*******************/

    public override void Destroy()
    {
        if (_pool.PooledObjects == null || _pool.PooledObjects.Count == 0)
        {
            return;
        }

        foreach (ICollectable collectable in _pool.PooledObjects)
        {
            float objectPosition = (collectable as MonoBehaviour).gameObject.transform.position.x;
            float destructionPointPosition = (_referenceObject as IGeneratorOperatorElement).DestructionPoint.transform.position.x;

            if (objectPosition < destructionPointPosition)
            {
                (collectable as MonoBehaviour).gameObject.SetActive(false);
            }
        }
    }
}
