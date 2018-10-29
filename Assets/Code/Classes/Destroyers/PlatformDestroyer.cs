/**
 * FTSWFOS - PlatformDestroyer - Concrete Class
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

/******************************/
/***** PLATFORM DESTROYER *****/
/******************************/

public class PlatformDestroyer : AbstractDestroyer<IPlatform>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    public PlatformDestroyer() : base()
    {
    }

    /**************************************************/
    /**************************************************/

    /*******************/
    /***** DESTROY *****/
    /*******************/

    /**
     * @access public
     */

    public override void Destroy()
    {
        if (_pool.PooledObjects == null || _pool.PooledObjects.Count == 0)
        {
            return;
        }

        foreach (IPlatform platform in _pool.PooledObjects)
        {
            float _objectWidth = (platform as MonoBehaviour).gameObject.GetComponent<BoxCollider2D>().size.x;
            float _objectPosition = (platform as MonoBehaviour).gameObject.transform.position.x;

            if ((_objectWidth/2 + _objectPosition) < _referenceObject.transform.position.x) {
                (platform as MonoBehaviour).gameObject.SetActive(false);
            }
        }
    }
}
