/**
 * FTSWFOS - IScore - Interface
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

/******************/
/***** ISCORE *****/
/******************/

public interface IScore
{
    int Value
    {
        get;
        set;
    }

    void IncreaseScore(int value);
    void DecreaseScore(int value);
    void ResetScore();
}