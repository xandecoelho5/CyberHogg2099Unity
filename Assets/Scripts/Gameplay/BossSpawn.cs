using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CyberHogg.Core;
using CyberHogg.Model;
using CyberHogg.Mechanics;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when cyber arrives bossZone;
    /// </summary>
    public class BossSpawn : Simulation.Event<BossSpawn>
    {
        CyberHoggModel model = Simulation.GetModel<CyberHoggModel>();

        public override void Execute()
        {
            model.hiddenForeground.SetActive(true);
            model.bossZone.SetActive(false);
            model.bossConfig.SetActive(true);
        }
    }
}

