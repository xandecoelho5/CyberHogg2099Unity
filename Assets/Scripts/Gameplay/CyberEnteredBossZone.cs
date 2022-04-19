using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CyberHogg.Core;
using CyberHogg.Model;
using CyberHogg.Mechanics;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when a player enters a trigger with a BossZone component.
    /// </summary>
    /// <typeparam name="CyberEnteredBossZone"></typeparam>
    public class CyberEnteredBossZone : Simulation.Event<CyberEnteredBossZone>
    {
        CyberHoggModel model = Simulation.GetModel<CyberHoggModel>();

        public override void Execute()
        {
            GameController.Instance.gameObject.GetComponent<AudioSource>().Stop();
            Simulation.Schedule<BossSpawn>(0);
        }
    }
}
