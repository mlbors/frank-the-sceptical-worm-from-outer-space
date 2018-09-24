/**
 * FTSWFOS - CameraFactory - Concrete Class
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

/**************************/
/***** CAMERA FACTORY *****/
/**************************/

public class CameraFactory : AbstractDIFactory<ICamera>, ICameraFactory<ICamera>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var GameObject _gameObject camera's game object
     * @var ICameraTarget _target targeted object
     */

    protected GameObject _gameObject;
    protected ICameraTarget _target;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @parm GameObject _gameObject camera's game object
     * @param DiContainer container DI container
     */

    public CameraFactory(DiContainer container, GameObject gameObject) : base (container)
    {
        Debug.Log("::: Camera Factory :::");
        _gameObject = gameObject;
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** GAME OBJECT GETTER/SETTER *****/
    /*************************************/

    /**
     * @access public
     */

    public GameObject GameObject
    {
        get { return _gameObject; }
        set { _gameObject = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** TARGET GETTER/SETTER *****/
    /********************************/

    /**
     * @access public
     */

    public ICameraTarget Target
    {
        get { return _target; }
        set { _target = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return ICamera
     */

    public override ICamera Create(params object[] constructorArguments)
    {
        Debug.Log("::: Creating Camera :::");

        Debug.Log(_target);
        if (_target == null)
        {
            return null;
        }

        ICamera camera;
        _container.Bind<ICamera>().To<Camera>().AsSingle();
        var prefab = _container.InstantiatePrefab(_gameObject);
        camera = _container.InstantiateComponent<Camera>(prefab, new object[]{});
        camera.CameraTarget = _target;
        Debug.Log("::: Camera created :::");
        return camera;
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** IVALIDATABLE VALIDATABLE *****/
    /************************************/

    /**
     * @access public
     */

    public override void Validate()
    {
      
    }
}