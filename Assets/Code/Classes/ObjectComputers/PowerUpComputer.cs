/**
 * FTSWFOS - PowerUpComputer - Concrete Class
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

/*****************************/
/***** POWER UP COMPUTER *****/
/*****************************/

public class PowerUpComputer : AbstractObjectComputer<ICollectable>
{
    /*********************/
    /***** CONSTRUCT *****/
    /*********************/

    /**
     * @access protected
     */

    public PowerUpComputer() : base()
    {
    }

    /**************************************************/
    /**************************************************/

    /************************************************/
    /***** IOBJECT COMPUTER EXECUTE COMPUTATION *****/
    /************************************************/

    /**
     * @access public
     */

    public override void ExecuteComputation()
    {
        _GeneratePowerUp();
    }

    /**************************************************/
    /**************************************************/

    /**************************/
    /***** GENERATE DEATH *****/
    /**************************/

    /**
     * @access protected
     */

    protected void _GeneratePowerUp()
    {
        IPlatform platform = (_referenceObject as IGeneratorOperatorElement<IPlatform>).Generator.CurrentObject;

        System.Random rnd = new System.Random();
        int amount = rnd.Next(0, 1);

        if (amount == 0)
        {
            return;
        }

        _currentObject = _pool.GetObject();
        (_currentObject as MonoBehaviour).transform.position = _ComputePosition(platform);
        (_currentObject as MonoBehaviour).gameObject.SetActive(true);
        _generatedObjects.Push(_currentObject);
    }

    /**************************************************/
    /**************************************************/

    /****************************/
    /***** COMPUTE POSITION *****/
    /****************************/

    /**
     * @access protected
     * @param IPlatform platform platform used as a reference
     * @return Vector3
     */

    protected Vector3 _ComputePosition(IPlatform platform)
    {
        float xPosition = _ComputeXPosition(platform);
        float yPosition = _ComputeYPosition(platform);

        Vector3 position = new Vector3(xPosition, yPosition, (_currentObject as MonoBehaviour).transform.position.z);
        _currentObject.X = xPosition;
        _currentObject.Y = yPosition;

        return position;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** COMPUTE X POSITION *****/
    /******************************/

    /**
     * @access protected
     * @param IPlatform platform platform used as a reference
     * @return float
     */

    protected float _ComputeXPosition(IPlatform platform)
    {
        float xPosition = 0.00f;
        float platformWidth = (platform as MonoBehaviour).gameObject.GetComponent<BoxCollider2D>().size.x;
        float platformPosition = (platform as MonoBehaviour).transform.position.x - platformWidth / 2.00f;
        float currentObjectWidth = (_currentObject as MonoBehaviour).gameObject.GetComponent<CircleCollider2D>().radius * 2.00f * 0.15f;
        float minPosition = platformPosition + (currentObjectWidth / 2.00f);
        float maxPosition = (platformPosition + platformWidth) - (currentObjectWidth / 2.00f);

        xPosition = UnityEngine.Random.Range(minPosition, maxPosition);

        return xPosition;
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** COMPUTE Y POSITION *****/
    /******************************/

    /**
     * @access protected
     * @param IPlatform platform platform used as a reference
     * @return float
     */

    protected float _ComputeYPosition(IPlatform platform)
    {
        float yPosition = 0.00f;
        float platformPosition = (platform as MonoBehaviour).transform.position.y;
        float platformHeight = (platform as MonoBehaviour).gameObject.GetComponent<BoxCollider2D>().size.y;
        float minPosition = platformPosition + platformHeight;
        float maxPosition = platformPosition + platformHeight * 2.00f;

        yPosition = UnityEngine.Random.Range(minPosition, maxPosition);

        return yPosition;
    }
}
