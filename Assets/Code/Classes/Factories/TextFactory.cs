/**
 * FTSWFOS - TextFactory - Concrete Class
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

/************************/
/***** TEXT FACTORY *****/
/************************/

public class TextFactory : AbstractDIFactory<Text>, ITextFactory<Text>
{
    /*********************/
    /***** ATTRIBUTS *****/
    /*********************/

    /**
     * @var TextType _type type of text
     * @var List<GameObject> _gameObjects texts to use       
     */

    protected TextType _type;
    protected List<GameObject> _gameObjects;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param TextType type type of text
     * @param List<GameObject> texts texts to use
     */

    public TextFactory(DiContainer container, List<GameObject> gameObjects, TextType type = TextType.Score) : base(container)
    {
        _type = type;
        _gameObjects = gameObjects;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** TYPE GETTER/SETTER *****/
    /******************************/

    /**
     * @access public
     */

    public TextType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** GAME OBJECTS GETTER/SETTER *****/
    /**************************************/

    /**
     * @access public
     */

    public List<GameObject> GameObjects
    {
        get { return _gameObjects; }
        set { _gameObjects = value; }
    }

    /**************************************************/
    /**************************************************/

    /******************/
    /***** CREATE *****/
    /******************/

    /**
     * @access public
     * @param params object constructorArguments comma-separated list of arguments
     * @return Text
     */

    public override Text Create(params object[] constructorArguments)
    {
        Text text;
        GameObject prefab;

        switch (_type)
        {
            case TextType.HighScore:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                text = prefab.transform.GetComponent<Text>();
                break;
            case TextType.Score:
                prefab = _container.InstantiatePrefab(_gameObjects[1]);
                text = prefab.transform.GetComponent<Text>();
                break;
            default:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                text = prefab.transform.GetComponent<Text>();
                break;
        }

        return text;
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

    }
}