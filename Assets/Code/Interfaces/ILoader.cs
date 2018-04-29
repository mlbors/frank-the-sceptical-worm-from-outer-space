/**
 * FTSWFOS - ILoader - Interface
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

/*******************/
/***** ILOADER *****/
/*******************/

public interface ILoader
{
    List<IManager> Managers
    {
        get;
        set;
    }

    void InitManagers();
    void AddManager(IManager manager);
    void RemoveManager(IManager manager);
}