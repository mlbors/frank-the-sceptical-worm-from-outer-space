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
     * @var GameObject _canvas canvas to use to render objects
     */

    protected TextType _type;
    protected List<GameObject> _gameObjects;
    protected GameObject _canvas;

    /**************************************************/
    /**************************************************/

    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param DiContainer container DI container
     * @param List<GameObject> texts texts to use
     * @param GameObject canvas canvas to use to render objects
     * @param TextType type type of text    
     */

    public TextFactory(DiContainer container, List<GameObject> gameObjects, GameObject canvas, TextType type = TextType.Score) : base(container)
    {
        _gameObjects = gameObjects;
        _canvas = canvas;
        _type = type;
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

    /********************************/
    /***** CANVAS GETTER/SETTER *****/
    /********************************/

    /**
     * @access public
     */

    public GameObject Canvas
    {
        get { return _canvas; }
        set { _canvas = value; }
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
                break;
            case TextType.Score:
                prefab = _container.InstantiatePrefab(_gameObjects[1]);
                break;
            default:
                prefab = _container.InstantiatePrefab(_gameObjects[0]);
                break;
        }

        prefab.transform.SetParent(_canvas.transform, false);
        text = prefab.transform.GetComponent<Text>();
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