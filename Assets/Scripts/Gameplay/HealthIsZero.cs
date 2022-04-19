using CyberHogg.Core;
using CyberHogg.Mechanics;
using static CyberHogg.Core.Simulation;

using UnityEngine;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when the player health reaches 0. This usually would result in a 
    /// PlayerDeath event.
    /// </summary>
    /// <typeparam name="HealthIsZero"></typeparam>
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        public Health health;

        public override void Execute()
        {
            var cyber = health.GetComponent<CyberController>();
            if (cyber != null) Schedule<CyberDeath>();

            var boss = health.GetComponent<BossController>();
            if (boss != null)
            {
                var ev = Schedule<BossDeath>();
                ev.boss = boss;
            }
        }
    }
}