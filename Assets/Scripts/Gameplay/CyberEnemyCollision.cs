using CyberHogg.Core;
using CyberHogg.Mechanics;
using CyberHogg.Model;
using UnityEngine;
using static CyberHogg.Core.Simulation;

namespace CyberHogg.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class CyberEnemyCollision : Simulation.Event<CyberEnemyCollision>
    {
        public EnemyController enemy;
        public CyberController player;

        CyberHoggModel model = Simulation.GetModel<CyberHoggModel>();

        public override void Execute()
        {
            if (player == null) // wasn't setted the player, so was the bullet that triggered
            {
                DecrementHealth();
                return;
            }

            bool willHurtEnemy = player.Bounds.center.y >= enemy.Bounds.max.y;

            if (willHurtEnemy) DecrementHealth(true);
            else Schedule<CyberDeath>();
        }

        void DecrementHealth(bool bounce = false)
        {
            var enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.Decrement();
                if (!enemyHealth.IsAlive)
                {
                    ScheduleDeath();
                    if (bounce) player.Bounce(2);
                }
                else if (bounce) player.Bounce(7);
            }
            else
            {
                ScheduleDeath();
                if (bounce) player.Bounce(2);
            }
        }

        void ScheduleDeath()
        {
            var boss = enemy.GetComponent<BossController>();
            if (boss == null)
                Schedule<EnemyDeath>().enemy = enemy;
        }
    }
}