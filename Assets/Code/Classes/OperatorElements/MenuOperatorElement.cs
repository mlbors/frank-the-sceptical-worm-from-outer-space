/**
 * FTSWFOS - MenuOperatorElement - Concrete Class
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

/*********************************/
/***** MENU OPERATOR ELEMENT *****/
/*********************************/

public class MenuOperatorElement : IOperatorElement, IObserver
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IMenuFactory _menuFactory factory object that creates other objects, here, IMenu
     * @var IDictionary<string, IMenu> _menus dictionary of menus    
     */

    protected IMenuFactory<IMenu> _menuFactory;
    protected IDictionary<string, IMenu> _menus = new Dictionary<string, IMenu>();

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     */

    public MenuOperatorElement(IMenuFactory<IMenu> menuFactory)
    {
        _menuFactory = menuFactory;
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    public void Init()
    {
        _menuFactory.Type = MenuType.Death;
        _menus["death"] = _menuFactory.Create();

        _menuFactory.Type = MenuType.Main;
        _menus["main"] = _menuFactory.Create();

        _menuFactory.Type = MenuType.Pause;
        _menus["pause"] = _menuFactory.Create();
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
            switch (info)
            {
                case ObservableEventType.Death:
                    _menus["death"].Activate();
                    break;

                case ObservableEventType.GameRestarts:
                    foreach (KeyValuePair<string, IMenu> menu in _menus)
                    {
                        menu.Value.Deactivate();
                    }
                    break;

                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }
}