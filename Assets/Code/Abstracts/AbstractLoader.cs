/**
 * FTSWFOS - AbstractLoader - Abstract Class
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

/***************************/
/***** ABSTRACT LOADER *****/
/***************************/

abstract public class AbstractLoader : MonoBehaviour, ILoader, IProduct
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IManager> _managers list of managers
     * @var IManagerFactory<IManager> _managerFactory factory object that creates other objects, here, IManager
     */

    protected List<IManager> _managers = new List<IManager>();
    protected IManagerFactory<IManager> _managerFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IManagerFactory managerFactory factory object that creates other objects, here, IManager
     */

    [Inject]
    public virtual void Construct(IManagerFactory<IManager> managerFactory)
    {
        _managerFactory = managerFactory;
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** MANAGERS GETTER/SETTER *****/
    /**********************************/

    /**
     * @access public
     */

    public List<IManager> Managers
    {
        get { return _managers; }
        set { _managers = value; }
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** ILOADER AWAKE *****/
    /*************************/

    /**
     * @access public
     */

    public abstract void Awake();

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** ILOADER INIT MANAGERS *****/
    /*********************************/

    /**
     * @access public
     */

    public abstract void InitManagers();

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ILOADER ADD MANAGER *****/
    /*******************************/

    /**
     * @access public
     * @param IManager manager manager to add
     */

    public virtual void AddManager(IManager manager)
    {
        Debug.Log("::: Adding manager :::");
        Debug.Log(manager);
        _managers.Add(manager);
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** ILOADER REMOVE MANAGER *****/
    /**********************************/

    /**
     * @access public
     * @param IManager manager manager to remove
     */

    public void RemoveManager(IManager manager)
    {
        _managers.Remove(manager);
    }
}
