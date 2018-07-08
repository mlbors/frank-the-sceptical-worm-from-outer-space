/**
 * FTSWFOS - GameOperator - Concrete Class
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
using Zenject;

/**************************************************/
/**************************************************/

/*************************/
/***** GAME OPERATOR *****/
/*************************/

public class GameOperator : AbstractOperator
{
    /**************************/
    /***** IOPERATOR INIT *****/
    /**************************/

    /**
     * @access public
     */

    public override void Init() 
    {
        Console.WriteLine("::: GameOperator Init :::");
    }

    /**************************************************/
    /**************************************************/

    /*****************************/
    /***** IOPERATOR OPERATE *****/
    /*****************************/

    /**
     * @access public
     */

    public override void Operate()
    {
        
    }
}
