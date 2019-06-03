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
     */

    [Inject]
    public override void Construct()
    {
        base.Construct();
    }

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** SET INITIAL POSITIONS *****/
    /*********************************/

    /**
     * @access protected
     */

    protected void _SetInitialPositions()
    {
        transform.position = new Vector3(0.00f, 0.00f, transform.position.z);
        _targetLastPosition = new Vector3(0.00f, _targetLastPosition.y, _targetLastPosition.z);
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
        _SetInitialPositions();
        _initialized = true;
        return _initialized;
    }

    /**************************************************/
    /**************************************************/

    /*****************/
    /***** RESET *****/
    /*****************/

    /**
     * @access public
     */

    public override void Reset()
    {
        _SetInitialPositions();
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
        if (_resetting)
        {
            _resetting = false;
            return;
        }

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

    /**
     * @access protected
     */

    protected void _MoveCamera()
    {
        _distanceToMove = (_cameraTarget as MonoBehaviour).transform.position.x - _targetLastPosition.x;

        float xPosition = transform.position.x + _distanceToMove;
        float yPosition = _targetLastPosition.y - (_targetLastPosition.y/1.50f);

        transform.position = new Vector3(xPosition, yPosition, transform.position.z);
    }
}
