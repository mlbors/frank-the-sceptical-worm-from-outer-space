/**
 * FTSWFOS - FoeOperatorElement - Concrete Class
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
/***** FOE OPERATOR ELEMENT *****/
/********************************/

public class FoeOperatorElement : AbstractGeneratorComponentOperatorElement<ICollectable>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IGeneratorFactory<IGenerator> generatorFactroy object that create other objects, here, IGenerator
     * @param IDestroyerFactory<IDestroyer> destroyerFactory object that create other objects, here, IDestroyer
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

    }

    /**************************************************/
    /**************************************************/

    /*************************************/
    /***** OPERATORELEMENT - OPERATE *****/
    /*************************************/

    public override void Operate()
    {
        
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
}