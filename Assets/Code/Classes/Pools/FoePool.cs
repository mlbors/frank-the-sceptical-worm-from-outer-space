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

public class FoePool : AbstractPool<IFoe>
{
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

    /**********************/
    /***** IPOOL INIT *****/
    /**********************/

    /**
     * @access public
     */

    public override void Init()
    {
        (_factory as IFoeFactory<IFoe>).Type = FoeType.Spike;
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
}
