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
using UnityEngine.UI;

using Zenject;

/**************************************************/
/**************************************************/

/*************************/
/***** SCORE FACTORY *****/
/*************************/

public class ScoreFactory : AbstractDIFactory<IScore>, IScoreFactory<IScore>
{   
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var Text _text text representing score    
     */

    protected Text _text;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param Text text text representing score     
     */

    public ScoreFactory(DiContainer container, Text text) : base (container)
    {
        _text = text;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** TEXT GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public Text Text
    {
        get { return _text; }
        set { _text = value; }
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
        score.Text = _text;

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