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

public interface IPool
{
    int Amount
    {
        get;
        set;
    }

    void Init();
    void FillPool();
    void Reset();
}