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

public class GameOperator : AbstractOperator, IGameOperator
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IOperatorElementFactory operatorElementFactory factory object that creates other objects, here, IOperatorElement
     */

    public GameOperator(IOperatorElementFactory<IOperatorElement> operatorElementFactory) : base(operatorElementFactory)
    {
        Debug.Log("::: GameOperator construct :::");
        _SetValues();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        _operatorElementFactory.Type = OperatorElementTypes.CameraOperatorElement;
        AddElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementTypes.CollectableOperatorElement;
        AddElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementTypes.FoeOperatorElement;
        AddElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementTypes.MenuOperatorElement;
        AddElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementTypes.PlatformOperatorElement;
        AddElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementTypes.PlayerOperatorElement;
        AddElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementTypes.ScoreOperatorElement;
        AddElement(_operatorElementFactory.Create());
    }

    /**************************/
    /***** IOPERATOR INIT *****/
    /**************************/

    /**
     * @access public
     */

    public override void Init() 
    {
        Debug.Log("::: GameOperator Init :::");
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
