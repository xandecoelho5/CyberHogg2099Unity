using System.Collections;
using System.Collections.Generic;
using CyberHogg.Gameplay;
using UnityEngine;
using static CyberHogg.Core.Simulation;

namespace CyberHogg.Mechanics
{
    /// <summary>
    /// BossZone components mark a collider which will schedule a
    /// CyberEnteredBossZone event when the player enters the trigger.
    /// </summary>
    public class BossZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<CyberController>();
            if (p != null)
            {
                Schedule<CyberEnteredBossZone>();
            }
        }
    }
}