/**
 * FTSWFOS - PlatformGenerator - Concrete Class
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

/**************************************************/
/**************************************************/

/******************************/
/***** PLATFORM GENERATOR *****/
/******************************/

public class PlatformGenerator : AbstractGeneratorComposite<IPlatform>, IPlatformGenerator
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access public
     * @param IOperatorElementFactory<IOperatorElement> operatorElementFactory object that create other objects, here, IOperatorElementFactory
     */

    public PlatformGenerator(IOperatorElementFactory<IOperatorElement> operatorElementFactory) : base(operatorElementFactory)
    {
        _SetValues();
    }

    /**************************************************/
    /**************************************************/

    /**********************/
    /***** SET VALUES *****/
    /**********************/

    protected void _SetValues()
    {
        _operatorElementFactory.Type = OperatorElementType.CollectableOperatorElement;
        AddOperatorElement(_operatorElementFactory.Create());

        _operatorElementFactory.Type = OperatorElementType.FoeOperatorElement;
        AddOperatorElement(_operatorElementFactory.Create());
    }

    /**************************************************/
    /**************************************************/

    /***********************************************/
    /***** IPLATFORM EXECUTE OPERATOR ELEMENTS *****/
    /***********************************************/

    /**
     * @access public
     */

    public override void ExecuteOperatorElements()
    {
        foreach (IOperatorElement element in _operatorElements)
        {
            element.Init();
            element.Operate();
        }
    }

    /**************************************************/
    /**************************************************/

    /********************/
    /***** GENERATE *****/
    /********************/

    public override void Generate()
    {

    }
}
