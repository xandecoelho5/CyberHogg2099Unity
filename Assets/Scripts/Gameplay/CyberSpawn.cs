using CyberHogg.Core;
using CyberHogg.Mechanics;
using CyberHogg.Model;
using UnityEngine;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class CyberSpawn : Simulation.Event<CyberSpawn>
    {
        CyberHoggModel model = Simulation.GetModel<CyberHoggModel>();

        public override void Execute()
        {
            var player = model.cyber;
            player.collider2d.enabled = true;
            player.controlEnabled = false;
            if (player.audioSource && player.respawnAudio)
                player.audioSource.PlayOneShot(player.respawnAudio);
            player.health.Increment();
            player.Teleport(model.spawnPoint.transform.position);
            player.jumpState = CyberController.JumpState.Grounded;
            player.animator.SetBool("dead", false);
            model.virtualCamera.m_Follow = player.transform;
            model.virtualCamera.m_LookAt = player.transform;
            Simulation.Schedule<EnableCyberInput>(1f);
            player.spriteRenderer.color = Color.white;

            if (model.hiddenForeground.activeSelf)
            {
                GameController.Instance.gameObject.GetComponent<AudioSource>().Play();
                model.hiddenForeground.SetActive(false);
                model.bossZone.SetActive(true);
                model.bossConfig.SetActive(false);
            }
        }
    }
}