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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/**************************************************/
/**************************************************/

/********************************/
/***** PALYER STATE FACTORY *****/
/********************************/

public class PlayerStateFactory : AbstractDIFactory<IState>, IPlayerStateFactory<IState>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var PlayerStates _type type of state
     * @var IStateSubject _subject subject of the state
     */

    protected PlayerStates _type;
    protected IStateSubject _subject;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param IStateSubject _subject subject of the state
     * @param PlayerStates type type of state
     */

    public PlayerStateFactory(DiContainer container, IStateSubject subject, PlayerStates type = PlayerStates.Standing) : base (container)
    {
        _type = type;
        _subject = subject;
    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** TYPES GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public PlayerStates Type
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

    public IStateSubject Subject
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

    public override IState Create(params object[] constructorArguments)
    {
        IState state;

        switch (_type)
        {
            case PlayerStates.Standing:
                state = _container.Instantiate<StandingPlayerState>(new object[] { _subject }) as IState;
                break;
            default:
                state = _container.Instantiate<StandingPlayerState>(new object[] { _subject }) as IState;
                break;
        }

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