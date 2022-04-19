using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CyberHogg.Model;
using static CyberHogg.Core.Simulation;
using CyberHogg.Core;
using CyberHogg.Gameplay;

namespace CyberHogg.Mechanics
{
    public class Projectile : MonoBehaviour
    {
        Rigidbody2D rigidbody2d;
        SpriteRenderer spriteRenderer;

        CyberHoggModel model = Simulation.GetModel<CyberHoggModel>();

        bool canColide;

        void Awake()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            if (transform.position.magnitude > model.virtualCamera.transform.position.magnitude + 20.0f) Destroy(gameObject);
        }

        public void Launch(Vector2 direction, float force)
        {
            canColide = true;
            if (direction.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (direction.x < -0.01f)
                spriteRenderer.flipX = true;
            rigidbody2d.AddForce(direction * force);
        }
        
        void OnCollisionEnter2D(Collision2D collision)
        {
            EnemyController e = collision.collider.GetComponent<EnemyController>();

            if (e != null && canColide)
            {
                canColide = false;
                var ev = Schedule<CyberEnemyCollision>();
                ev.enemy = e;
                ev.player = null;
            }

            Destroy(gameObject);
        }

        //void OnTriggerEnter2D(Collider2D collision)
        //{
        //    EnemyController e = collision.gameObject.GetComponent<EnemyController>();

        //    if (e != null && canColide)
        //    {
        //        canColide = false;
        //        var ev = Schedule<CyberEnemyCollision>();
        //        ev.enemy = e;
        //        ev.player = null;
        //    }

        //    Destroy(gameObject);
        //}
    }
}
