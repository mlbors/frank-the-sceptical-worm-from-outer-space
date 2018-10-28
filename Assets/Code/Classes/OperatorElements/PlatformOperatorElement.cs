/**
 * FTSWFOS - PlatformOperatorElement - Concrete Class
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

/*************************************/
/***** PLATFORM OPERATOR ELEMENT *****/
/*************************************/

public class PlatformOperatorElement : AbstractGeneratorOperatorElement<IPlatform>, IPlatformOperatorElement
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @param IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
     * @param List points list of points
     */

    [Inject]
    public override void Construct(IGeneratorFactory<IGenerator> generatorFactory,
                                   IDestroyerFactory<IDestroyer> destroyerFactory)
    {
        base.Construct(generatorFactory, destroyerFactory);
    }

    /**************************************************/
    /**************************************************/

    /**********************************/
    /***** OPERATORELEMENT - INIT *****/
    /**********************************/

    public override void Init()
    {
        _generatorFactory.Type = GeneratorType.Platform;
        Generator = _generatorFactory.Create() as IGenerator<IPlatform>;

        _destroyerFactory.Type = DestroyerType.Platform;
        Destroyer = _destroyerFactory.Create() as IDestroyer<IPlatform>;

        _generator.ReferenceObject = this;
    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** OPERATORELEMENT - OPERATE *****/
    /*************************************/

    public override void Operate()
    {
        if (_generationPoint == null || _destructionPoint == null)
        {
            Debug.Log("No generation and destruction points");
            return;
        }

        if (_IsGenerationPointAhead())
        {
            CallGenerator();
            _MoveOperator();
            _generator.CurrentObject = null;
        }
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** IOBSERVER UPDATE *****/
    /****************************/

    /**
     * @access public
     */

    public void ObserverUpdate(string info, object data)
    {
        if (info == "camera created")
        {
            Debug.Log("Setting generation and destruction points");
            GenerationPoint = (data as List<Transform>)[0];
            DestructionPoint = (data as List<Transform>)[1];
        }
    }

    /**************************************************/
    /**************************************************/

    /******************************************************/
    /***** IGENERATOR OPERATOR ELEMENT CALL GENERATOR *****/
    /******************************************************/

    public override void CallGenerator()
    {
        _generator.Generate();
    }

    /**************************************************/
    /**************************************************/

    /******************************************************/
    /***** IGENERATOR OPERATOR ELEMENT CALL DESTROYER *****/
    /******************************************************/

    public override void CallDestroyer()
    {
        _destroyer.Destroy();
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
        Operate();
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** IS GENERATION POINT BEHIND *****/
    /**************************************/

    /**
     * @access protected
     * @return bool
     */

    protected bool _IsGenerationPointAhead()
    {
        return transform.position.x < _generationPoint.position.x;
    }

    /**************************************************/
    /**************************************************/

    /**************************************/
    /***** IS GENERATION POINT BEHIND *****/
    /**************************************/

    /**
     * @access protected
     */

    protected void _MoveOperator()
    {
        float generatedObjectWidth = (_generator.CurrentObject as MonoBehaviour).gameObject.GetComponent<BoxCollider2D>().size.x;
        float generatedObjectXPos = (_generator.CurrentObject as MonoBehaviour).gameObject.transform.position.x;
        transform.position = new Vector3(generatedObjectWidth/2 + generatedObjectXPos, transform.position.y, transform.position.z);
    }
}