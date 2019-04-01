/**
 * FTSWFOS - AbstractScore - Abstract Class
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

/**************************************************/
/**************************************************/

/**************************/
/***** ABSTRACT SCORE *****/
/**************************/

abstract public class AbstractScore : IScore
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var int _value score value
     * @var Text _text text representing score    
     */

    protected int _value = 0;
    protected Text _text;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     */

    protected AbstractScore()
    {

    }

    /**************************************************/
    /**************************************************/

    /*******************************/
    /***** VALUE GETTER/SETTER *****/
    /*******************************/

    /**
     * @access public
     */

    public int Value 
    {
        get { return _value; }
        set { _value = value; }
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

    /*********************************/
    /***** ISCORE INCREASE SCORE *****/
    /*********************************/

    /**
     * @access public
     */

    public virtual void IncreaseScore(int value = 1)
    {
        _value += value;
    }

    /**************************************************/
    /**************************************************/

    /*********************************/
    /***** ISTATE DECREASE SCORE *****/
    /*********************************/

    /**
     * @access public
     */

    public virtual void DecreaseScore(int value = 1)
    {
        _value -= value;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** ISTATE RESET SCORE *****/
    /******************************/

    /**
     * @access public
     */

    public virtual void ResetScore()
    {
        _value = 0;
    }

}