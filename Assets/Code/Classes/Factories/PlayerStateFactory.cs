/**
 * FTSWFOS - PlayerStateFactory - Concrete Class
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

/********************************/
/***** PLAYER STATE FACTORY *****/
/********************************/

public class PlayerStateFactory : AbstractDIFactory<IPlayerState>, IPlayerStateFactory<IPlayerState>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var IPlayerInputHandlerFactory<IStateInputHandler> _inputHandlerFactory input handler factory
     * @var PlayerState _type type of state
     * @var IPlayerStateSubject _subject subject of the state
     */

    protected IPlayerInputHandlerFactory<IStateInputHandler> _inputHandlerFactory;
    protected PlayerState _type;
    protected IPlayerStateSubject _subject;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param PlayerState type type of state
     */

    public PlayerStateFactory(DiContainer container, IPlayerInputHandlerFactory<IStateInputHandler> inputHandlerFactory, PlayerState type = PlayerState.Standing) : base(container)
    {
        _inputHandlerFactory = inputHandlerFactory;
        _type = type;
    }

    /**************************************************/
    /**************************************************/

    /***********************************************/
    /***** INPUT HANDLER FACTORY GETTER/SETTER *****/
    /***********************************************/

    /**
     * @access public
     */

    public IPlayerInputHandlerFactory<IStateInputHandler> InputHandlerFactory
    {
        get { return _inputHandlerFactory; }
        set { _inputHandlerFactory = value; }
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** TYPES GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public PlayerState Type
    {
        get { return _type; }
        set { _type = value; }
    }

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** SUBJECT GETTER/SETTER *****/
    /*********************************/

    /**
     * @access public
     */

    public IPlayerStateSubject Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return IState
     */

    public override IPlayerState Create(params object[] constructorArguments)
    {
        if (_subject == null) {
            throw new Exception("No subject defined");
        }

        IPlayerState state;
        IStateInputHandler stateInputHandler;

        switch (_type)
        {
            case PlayerState.Standing:
                state = _container.Instantiate<StandingPlayerState>(new object[] { });
                _inputHandlerFactory.Type = PlayerInputHandlerType.Standing;
                stateInputHandler = _inputHandlerFactory.Create();
                break;
            case PlayerState.Running:
                state = _container.Instantiate<RunningPlayerState>(new object[] { });
                _inputHandlerFactory.Type = PlayerInputHandlerType.Running;
                stateInputHandler = _inputHandlerFactory.Create();
                break;
            case PlayerState.Jumping:
                state = _container.Instantiate<JumpingPlayerState>(new object[] { });
                _inputHandlerFactory.Type = PlayerInputHandlerType.Running;
                stateInputHandler = _inputHandlerFactory.Create();
                break;
            case PlayerState.DoubleJumping:
                state = _container.Instantiate<DoubleJumpingPlayerState>(new object[] { });
                _inputHandlerFactory.Type = PlayerInputHandlerType.Running;
                stateInputHandler = _inputHandlerFactory.Create();
                break;
            default:
                state = _container.Instantiate<StandingPlayerState>(new object[] { });
                _inputHandlerFactory.Type = PlayerInputHandlerType.Standing;
                stateInputHandler = _inputHandlerFactory.Create();
                break;
        }

        state.StateSubject = _subject;
        state.StateInputHandler = stateInputHandler;

        return state;
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
        _container.Instantiate<StandingPlayerState>();
    }
}