/**
 * FTSWFOS - IPool - Interface
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

public interface IPool<T>
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

    int Amount
    {
        get;
        set;
    }

    IFactory<T> Factory
    {
        get;
        set;
    }

    void Init();
    T InstantiateNewObject();
    void AddObject(T pooledObject);
    void RemoveObject(T pooledObject);
    void FillPool();
    T GetObject();
    bool CheckIfObjectAvailable(T currentObject);
}