using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CyberHogg.Gameplay;
using static CyberHogg.Core.Simulation;

namespace CyberHogg.Mechanics
{
    [RequireComponent(typeof(EnemyController), typeof(Collider2D))]
    public class BossController : EnemyController
    {
        internal Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    var player = collision.gameObject.GetComponent<CyberController>();
        //    if (player != null)
        //    {
        //        var ev = Schedule<CyberEnemyCollision>();
        //        ev.player = player;
        //        ev.enemy = this;
        //    }
        //}
    }
}
