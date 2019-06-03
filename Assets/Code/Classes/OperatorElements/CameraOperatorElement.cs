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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/**************************************************/
/**************************************************/

/***********************************/
/***** CAMERA OPERATOR ELEMENT *****/
/***********************************/

public class CameraOperatorElement : ICameraOperatorElement, IObserver, IObservable
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var List<IObserver> _observers list of observers
     * @var ICamera _camera camera object
     * @var ICameraFactory cameraFactory factory object that creates other objects, here, ICamera
     */

    protected List<IObserver> _observers = new List<IObserver>();
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

    /***********************************/
    /***** OBSERVERS GETTER/SETTER *****/
    /***********************************/

    /**
     * @access public
     */

    public List<IObserver> Observers
    {
        get { return _observers; }
        set { _observers = value; }
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
            _camera = _cameraFactory.Create();
            Notify(ObservableEventType.CameraInitialized, _camera);
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

    public void ObserverUpdate(ObservableEventType info, object data)
    {
        try
        {
            switch(info)
            {
                case ObservableEventType.GameRestarts:
                    _camera.Reset();
                    _camera.Resetting = true;
                    break;

                case ObservableEventType.PlayerCreated:
                    CameraFactory.Target = data as ICameraTarget;
                    _CreateCamera();
                    Transform generationPoint = (_camera as MonoBehaviour).transform.Find("ObjectsGenerationPoint");
                    Transform destructionPoint = (_camera as MonoBehaviour).transform.Find("ObjectsDestructionPoint");
                    List<Transform> points = new List<Transform>() { generationPoint, destructionPoint };
                    Notify(ObservableEventType.CameraCreated, points);
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

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IOBSERVABLE - ATTACH *****/
    /********************************/

    /**
     * @access private
     * @param IObserver observer observer to attach
     */

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    /**************************************************/
    /**************************************************/

    /********************************/
    /***** IOBSERVABLE - DETACH *****/
    /********************************/

    /**
     * @access private
     * @param IObserver observer observer to detach
     */

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** IOBSERVABLE NOTIFY *****/
    /******************************/

    /**
     * @access private
     * @param String info info for update
     */

    public void Notify(ObservableEventType info, object data)
    {
        foreach (IObserver o in _observers)
        {
            o.ObserverUpdate(info, data);
        }
    }
}