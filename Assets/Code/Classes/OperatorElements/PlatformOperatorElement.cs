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

public class PlatformOperatorElement : AbstractGeneratorOperatorElement<IPlatform>
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
                                   IDestroyerFactory<IDestroyer> destroyerFactory,
                                   List<GameObject> points)
    {
        base.Construct(generatorFactory, destroyerFactory, points);
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
        if (_IsGenerationPointAhead()) {
            CallGenerator();
            _MoveOperator();
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
        Debug.Log(_generationPoint.transform.position.x);
        return transform.position.x < _generationPoint.transform.position.x;
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
        float generatedObjectWidth = (_generator.CurrentObject as MonoBehaviour).GetComponent<BoxCollider2D>().size.x;
        transform.position = new Vector3(transform.position.x + (generatedObjectWidth / 2), transform.position.y, transform.position.z);
    }
}