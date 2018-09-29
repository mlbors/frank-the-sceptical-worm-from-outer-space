/**
 * FTSWFOS - IPoolGeneric - Interface
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

/*****************/
/***** IPOOL *****/
/*****************/

public interface IPool<T> : IPool
{
    T PooledObject
    {
        get;
        set;
    }

    List<T> PooledObjects
    {
        get;
        set;
    }

    IFactory<T> Factory
    {
        get;
        set;
    }

    T InstantiateNewObject();
    void AddObject(T pooledObject);
    void RemoveObject(T pooledObject);
    T GetObject();
    bool CheckIfObjectAvailable(T currentObject);
}