/**
 * FTSWFOS - Camera - Concrete Class
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

/******************/
/***** CAMERA *****/
/******************/

public class Camera : AbstractCamera
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Vector3 _targetLastPosition target last position
     * @var float _distanceToMove distance to move
     */

    protected Vector3 _targetLastPosition;
    protected float _distanceToMove;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     * @param ICameraTarget cameraTarget camera's target
     */

    [Inject]
    public override void Construct(ICameraTarget cameraTarget)
    {
        base.Construct(cameraTarget);
    }

    /**************************************************/
    /**************************************************/

    /***********************/
    /***** INIT CAMERA *****/
    /***********************/

    /**
     * @access protected
     */

    protected bool _InitCamera()
    {
        Debug.Log("::: Init camera :::");
        transform.position = new Vector3(0, 0, transform.position.z);
        _initialized = true;
        return _initialized;
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** AWAKE *****/
    /*****************/

    /**
     * @access public
     */

    public override void Awake()
    {
        Debug.Log("::: player awake :::");
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** START *****/
    /*****************/

    /**
     * @access public
     */

    public override void Start()
    {
        Debug.Log("::: camera start :::");

        if (!_initialized)
        {
            _InitCamera();
            return;
        }
        _GetTargetLastPostion();
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** UPDATE *****/
    /******************/

    /**
     * @access public
     */

    public override void Update()
    {
        _MoveCamera();
        _GetTargetLastPostion();
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** GET TARGET LAST POSITION *****/
    /************************************/

    protected Vector3 _GetTargetLastPostion()
    {
        _targetLastPosition = (_cameraTarget as MonoBehaviour).transform.position;
        return _targetLastPosition;
    }

    /**************************************************/
    /**************************************************/

    /***********************/
    /***** MOVE CAMERA *****/
    /***********************/

    protected void _MoveCamera()
    {
        _distanceToMove = (_cameraTarget as MonoBehaviour).transform.position.x - _targetLastPosition.x;
        float xPosition = transform.position.x + _distanceToMove;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

    }
}
