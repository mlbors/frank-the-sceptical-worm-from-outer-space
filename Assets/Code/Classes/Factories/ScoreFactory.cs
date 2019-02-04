/**
 * FTSWFOS - ScoreFactory - Concrete Class
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

/*************************/
/***** SCORE FACTORY *****/
/*************************/

public class ScoreFactory : AbstractDIFactory<IScore>, IScoreFactory<IScore>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     */

    public ScoreFactory(DiContainer container) : base (container)
    {
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return IScore
     */

    public override IScore Create(params object[] constructorArguments)
    {
       IScore score;

        score = _container.Instantiate<Score>() as IScore;

        return score;
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
        _container.Instantiate<Score>();
    }
}