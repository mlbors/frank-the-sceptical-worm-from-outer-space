/**
 * FTSWFOS - FoePool - Concrete Class
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

/********************/
/***** FOE POOL *****/
/********************/

public class FoePool : AbstractPool<IFoe>, IFoePool
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var FoeType _neededType type of foe needed
     * @var IOperator _gameOperator object managing game        
     * @var IOperatorElement _scoreOperator object managing score     
     */

    protected FoeType _neededType;
    protected IOperator _gameOperator;
    protected IOperatorElement _scoreOperator;

    /**************************************************/
    /**************************************************/


    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param Int amount initinal amount
     * @param IFactory factory object that other creates objects, here object of type T
     */

    public FoePool(IFoeFactory<IFoe> factory, int amount = 5) : base(amount, factory)
    {
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** NEEDED TYPE GETTER/SETTER *****/
    /*************************************/

    /**
     * @access public
     */

    public FoeType NeedType
    {
        get { return _neededType; }
        set { _neededType = value; }
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** GAME OPERATOR GETTER/SETTER *****/
    /***************************************/

    public IOperator GameOperator
    {
        get { return _gameOperator; }
        set { _gameOperator = value; }
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** SCORE OPERATOR GETTER/SETTER *****/
    /****************************************/

    public IOperatorElement ScoreOperator
    {
        get { return _scoreOperator; }
        set { _scoreOperator = value; }
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** IPOOL INIT *****/
    /**********************/

    /**
     * @access public
     */

    public override void Init()
    {
        (_factory as IFoeFactory<IFoe>).Type = FoeType.Spike;
        _CheckFactoryScoreOperator();
        FillPool();
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** IPOOL INSTANTIATE NEW OBJECT *****/
    /****************************************/

    /**
     * @access public
     * @return IFoe
     */

    public override IFoe InstantiateNewObject()
    {
        _CheckFactory();
        (_factory as IFoeFactory<IFoe>).Type = FoeType.Spike;

        IFoe foe = _factory.Create();

        (foe as MonoBehaviour).gameObject.SetActive(false);
        return foe;
    }

    /**************************************************/
    /**************************************************/

    /*******************************************/
    /***** IPOOL CHECK IF OBJECT AVAILABLE *****/
    /*******************************************/

    /**
     * @access public
     * @param IFoe currentObject object to check
     * @return Bool
     */

    public override bool CheckIfObjectAvailable(IFoe currentObject)
    {
        return !(currentObject as MonoBehaviour).gameObject.activeInHierarchy;
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** CHECK FACTORY *****/
    /*************************/

    /**
     * @access protected
     */

    protected void _CheckFactory()
    {
        _CheckFactoryGameOperator();
        _CheckFactoryScoreOperator();
    }

    /**************************************************/
    /**************************************************/

    /***************************************/
    /***** CHECK FACTORY GAME OPERATOR *****/
    /***************************************/

    /**
     * @access protected
     */

    protected void _CheckFactoryGameOperator()
    {
        if ((_factory as IFoeFactory<IFoe>).GameOperator == null)
        {
            (_factory as IFoeFactory<IFoe>).GameOperator = _gameOperator;
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** CHECK FACTORY SCORE OPERATOR *****/
    /****************************************/

    /**
     * @access protected
     */

    protected void _CheckFactoryScoreOperator()
    {
        if ((_factory as IFoeFactory<IFoe>).ScoreOperator == null)
        {
            (_factory as IFoeFactory<IFoe>).ScoreOperator = _scoreOperator;
        }
    }
}
