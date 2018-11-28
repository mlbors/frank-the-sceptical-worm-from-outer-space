/**
 * FTSWFOS - FoeDestroyer - Concrete Class
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
/***** FOE DESTROYER *****/
/*************************/

public class FoeDestroyer : AbstractDestroyer<IFoe>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    public FoeDestroyer() : base()
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

        foreach (IFoe foe in _pool.PooledObjects)
        {
            float objectPosition = (foe as MonoBehaviour).gameObject.transform.position.x;
            float destructionPointPosition = (_referenceObject as IGeneratorOperatorElement).DestructionPoint.transform.position.x;

            if (objectPosition < destructionPointPosition)
            {
                (foe as MonoBehaviour).gameObject.SetActive(false);
            }
        }
    }
}
