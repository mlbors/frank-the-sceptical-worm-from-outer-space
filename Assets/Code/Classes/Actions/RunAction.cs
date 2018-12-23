/**
 * FTSWFOS - RunAction - Concrete Classe
 *
 * @since       2018.01.09
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/**************************************************/
/**************************************************/

/**********************/
/***** RUN ACTION *****/
/**********************/

public class RunAction : IAction
{
    /***************************/
    /***** IACTION EXECUTE *****/
    /***************************/

    /**
     * @access public
     * @param ICommandSubject subject subject on which action is operated
     */

    public void Perform([Optional] ICommandSubject subject)
    {
        if (subject != null)
        {
            try 
            {
                Vector2 vector = (subject as IPlayer).Rigidbody.velocity;

                float y = vector.y;
                float moveSpeed = _ComputeMoveSpeed(subject);

                (subject as IPlayer).Rigidbody.velocity = new Vector2(moveSpeed, y);
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    /**************************************************/
    /**************************************************/

    /******************************/
    /***** COMPUTE MOVE SPEED *****/
    /******************************/

    /**
     * @access protected
     * @param ICommandSubject subject subject on which action is operated
     * @return float
     */

    protected float _ComputeMoveSpeed(ICommandSubject subject)
    {
        float speedMilestoneCount = (subject as IPlayer).SpeedMilestoneCount;
        float speedIncreaseMilestone = (subject as IPlayer).SpeedIncreaseMilestone;
        float speedMultiplier = (subject as IPlayer).SpeedMultiplier;
        float moveSpeed = (subject as IPlayer).MoveSpeed;

        if ((subject as MonoBehaviour).transform.position.x >= speedMilestoneCount)
        {
            (subject as IPlayer).SpeedMilestoneCount += speedIncreaseMilestone;
            (subject as IPlayer).SpeedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            (subject as IPlayer).MoveSpeed = moveSpeed * speedMultiplier;
        }

        return (subject as IPlayer).MoveSpeed;
    }
}