/**
 * FTSWFOS - ObserverbaleEventType - Enum
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

/*********************************/
/***** OBSERVABLE EVENT TYPE *****/
/*********************************/

public enum ObservableEventType
{
    BonusHitten,
    DeathHitten,
    CameraCreated,
    CameraInitialized,
    NegativeBonusHitten,
    None,
    PlayerCreated,
    PlayerGrounded,
    PlatformObjectAdded,
    PowerUpHitten,
    SpikeHitten
}