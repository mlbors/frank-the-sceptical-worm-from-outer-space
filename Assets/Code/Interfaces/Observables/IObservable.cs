/**
 * FTSWFOS - IObservable - Interface
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

/***********************/
/***** IOBSERVABLE *****/
/***********************/

public interface IObservable
{
    List<IObserver> Observers
    {
        get;
        set;
    }

    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(ObservableEventType info, object data);
}