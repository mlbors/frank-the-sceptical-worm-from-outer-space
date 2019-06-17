/**
 * FTSWFOS - DeathBox - Concrete Class
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

/*********************/
/***** DEATH BOX *****/
/*********************/

public class DeathBox : AbstractDeathBox
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
        transform.position = new Vector3(0.00f, -10.00f, transform.position.z);
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

    protected bool _InitDeathBox()
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
            _InitDeathBox();
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

        _MoveDeathBox();
        _GetTargetLastPostion();
    }

    /**************************************************/
    /**************************************************/

    /************************************/
    /***** GET TARGET LAST POSITION *****/
    /************************************/

    protected Vector3 _GetTargetLastPostion()
    {
        _targetLastPosition = _targetObject.transform.position;
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

    protected void _MoveDeathBox()
    {
        _distanceToMove = _targetObject.transform.position.x - _targetLastPosition.x;

        float xPosition = transform.position.x + _distanceToMove;

        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** IDEATH BOX OPERATE *****/
    /******************************/

    /**
     * @access public
     */

    public override void Operate()
    {
        Notify(ObservableEventType.DeathHitten, null);
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** ON TRIGGER ENTER 2D *****/
    /*******************************/

    /**
     * @access public
     */

    public override void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "Player" && otherObject.GetType() == typeof(BoxCollider2D))
        {
            Operate();
        }
    }
}
 