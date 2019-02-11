/**
 * FTSWFOS - EnvironmentOperatorElement - Concrete Class
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
using Zenject;

/**************************************************/
/**************************************************/

/****************************************/
/***** ENVIRONMENT OPERATOR ELEMENT *****/
/****************************************/

public class EnvironmentOperatorElement : IEnvironmentOperatorElement
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IEnvironmentObject> _environmentObjects list of generated object
     * @var IEnvironmentObjectFactory environmentObjectFactory factory object that creates other objects, here, IEnvironmentObject
     */

    protected List<IEnvironmentObject> _environmentObjects;
    protected IEnvironmentObjectFactory<IEnvironmentObject> _environmentObjectFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IEnvironmentObjectFactory environmentObjectFactory factory object that creates other objects, here, IEnvironmentObject
     */

    public EnvironmentOperatorElement(IEnvironmentObjectFactory<IEnvironmentObject> environmentObjectFactory)
    {
        _SetValues(environmentObjectFactory);
    }

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param IEnvironmentObjectFactory environmentObjectFactory factory object that creates other objects, here, IEnvironmentObject
     */

    protected void _SetValues(IEnvironmentObjectFactory<IEnvironmentObject> environmentObjectFactory)
    {
        _environmentObjectFactory = environmentObjectFactory;
    }

    /**************************************************/
    /**************************************************/

    /****************************************************/
    /***** ENVIRONMENT OBJECT FACTORY GETTER/SETTER *****/
    /****************************************************/

    /**
     * @access public
     */

    public IEnvironmentObjectFactory<IEnvironmentObject> EnvironmentObjectFactory
    {
        get { return _environmentObjectFactory; }
        set { _environmentObjectFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /*********************************************/
    /***** ENVIRONMENT OBJECTS GETTER/SETTER *****/
    /*********************************************/

    /**
     * @access public
     */

    public List<IEnvironmentObject> EnvironmentObjects
    {
        get { return _environmentObjects; }
        set { _environmentObjects = value; }
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    /**
     * @access public
     */

    public void Init()
    {
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** OPERATORELEMENT - OPERATE *****/
    /*************************************/

    /**
     * @access public
     */

    public void Operate()
    {
    }
}