/**
 * FTSWFOS - IPool - Interface
 *
 * @since       09.01.2018
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
/***** IPOOL *****/
/*****************/

public interface IPool
{
    GameObject PooledObject
    {
        get;
        set;
    }

    List<GameObject> PooledObjects
    {
        get;
        set;
    }

    int Amount
    {
        get;
        set;
    }

    void Init();
    void AddObject(GameObject gameObject);
    void RemoveObject(GameObject gameObject);
}