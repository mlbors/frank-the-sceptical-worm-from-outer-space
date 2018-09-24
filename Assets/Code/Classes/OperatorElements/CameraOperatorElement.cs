/**
 * FTSWFOS - CameraOperatorElement - Concrete Class
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

/***********************************/
/***** CAMERA OPERATOR ELEMENT *****/
/***********************************/

public class CameraOperatorElement : ICameraOperatorElement
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var ICamera _camera camera object
     * @var ICameraFactory cameraFactory factory object that creates other objects, here, ICamera
     */

    protected ICamera _camera;
    protected ICameraFactory<ICamera> _cameraFactory;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param ICameraFactory cameraFactory factory object that creates other objects, here, ICamera
     */

    public CameraOperatorElement(ICameraFactory<ICamera> cameraFactory)
    {
        _SetValues(cameraFactory);
    }

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param ICameraFactory cameraFactory factory object that creates other objects, here, ICamera
     */

    protected void _SetValues(ICameraFactory<ICamera> cameraFactory)
    {
        CameraFactory = cameraFactory;
    }

    /**************************************************/
    /**************************************************/

    /****************************************/
    /***** CAMERA FACTORY GETTER/SETTER *****/
    /****************************************/

    /**
     * @access public
     */

    public ICameraFactory<ICamera> CameraFactory
    {
        get { return _cameraFactory; }
        set { _cameraFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** CAMERA GETTER/SETTER *****/
    /********************************/

    /**
     * @access public
     */

    public ICamera Camera
    {
        get { return _camera; }
        set { _camera = value; }
    }

    /**************************************************/
    /**************************************************/

    /*************************/
    /***** CREATE CAMERA *****/
    /*************************/

    /**
     * @access protected
     */

    protected void _CreateCamera()
    {
        if (_camera == null)
        {
            Camera = _cameraFactory.Create();
        }
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

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     */

    public void ObserverUpdate(string info, object data)
    {
        if (info == "player created")
        {
            Debug.Log("Observer updating");
            CameraFactory.Target = data as ICameraTarget;
            _CreateCamera();
        }
    }
}