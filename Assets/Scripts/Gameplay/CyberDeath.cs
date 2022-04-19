using System.Collections;
using System.Collections.Generic;
using CyberHogg.Core;
using CyberHogg.Model;
using UnityEngine;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="CyberDeath"></typeparam>
    public class CyberDeath : Simulation.Event<CyberDeath>
    {
        CyberHoggModel model = Simulation.GetModel<CyberHoggModel>();

        public override void Execute()
        {
            var player = model.cyber;
            if (player.health.IsAlive)
            {
                player.health.Die();
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                player.collider2d.enabled = false;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.animator.SetBool("dead", true);
                player.spriteRenderer.color = Color.red;
                Simulation.Schedule<CyberSpawn>(2);
            }
        }
    }
}