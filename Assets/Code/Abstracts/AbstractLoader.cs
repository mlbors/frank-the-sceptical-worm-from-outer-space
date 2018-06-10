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
     * @var GameObject _gameObject loader's game object
     * @var List<IManager> _managers list of managers
     */

    protected GameObject _gameObject;
    protected List<IManager> _managers;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param GameObject gameObject platform's game object
     */

    [Inject]
    public virtual void Construct(GameObject gameObject)
    {
        _gameObject = gameObject;
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

    public void AddManager(IManager manager)
    {
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
