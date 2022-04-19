using CyberHogg.Core;
using CyberHogg.Mechanics;
using CyberHogg.Model;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when the health component on boss has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="BossDeath"></typeparam>
    public class BossDeath : Simulation.Event<BossDeath>
    {
        public BossController boss;

        public override void Execute()
        {
            //boss._collider.enabled = false;
            boss.control.enabled = false;
            if (boss._audio && boss.ouch)
                boss._audio.PlayOneShot(boss.ouch);

            boss.plasmaEffect.Play();
            boss.animator.SetTrigger("death");
            boss._audio.clip = null;

            boss.StartCoroutine(WaitForSceneLoad());
        }

        private IEnumerator WaitForSceneLoad()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("WinScene");
        }
    }
}