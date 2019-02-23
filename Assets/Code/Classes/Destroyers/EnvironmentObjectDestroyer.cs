/**
 * FTSWFOS - EnvironmentObjectDestroyer - Concrete Class
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

/****************************************/
/***** ENVIRONMENT OBJECT DESTROYER *****/
/****************************************/

public class EnvironmentObjectDestroyer : AbstractDestroyer<IEnvironmentObject>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    public EnvironmentObjectDestroyer() : base()
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

        foreach (IEnvironmentObject environmentObject in _pool.PooledObjects)
        {
            float objectPosition = (environmentObject as MonoBehaviour).gameObject.transform.position.x;
            float destructionPointPosition = (_referenceObject as IGeneratorOperatorElement).DestructionPoint.transform.position.x;

            if (objectPosition < destructionPointPosition)
            {
                (environmentObject as MonoBehaviour).gameObject.SetActive(false);
            }
        }
    }
}
