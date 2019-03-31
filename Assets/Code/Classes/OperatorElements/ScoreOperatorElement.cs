/**
 * FTSWFOS - ScoreOperatorElement - Concrete Class
 *
 * @since       2018.01.09
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/**************************************************/
/**************************************************/

/**********************************/
/***** SCORE OPERATOR ELEMENT *****/
/**********************************/

public class ScoreOperatorElement : IOperatorElement, IObserver
{
    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    public void Init()
    {

    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** OPERATORELEMENT - OPERATE *****/
    /*************************************/

    public void Operate()
    {
        
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     */

    public void ObserverUpdate(ObservableEventType info, object data)
    {
        try
        {
            if (info == ObservableEventType.BonusHitten)
            {
                Debug.Log("Bonus hitten");
            }
        }
        catch (Exception e)
        {
            Debug.Log($"Exception thrown: {e.Message}");
        }
    }
}