using System.Collections;
using System.Collections.Generic;
using CyberHogg.Gameplay;
using UnityEngine;
using static CyberHogg.Core.Simulation;

namespace CyberHogg.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// CyberEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<CyberController>();
            if (p != null)
            {
                var ev = Schedule<CyberEnteredDeathZone>();
                ev.deathzone = this;
            }
        }
    }
}