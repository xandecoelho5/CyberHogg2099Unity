using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CyberHogg.Model;
using CyberHogg.Core;
using CyberHogg.Gameplay;
using static CyberHogg.Core.Simulation;

namespace CyberHogg.Mechanics
{
    public class CyberController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;
        public AudioClip shootingAudio;

        public float maxSpeed = 7;
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        public Collider2D collider2d;
        public AudioSource audioSource;
        public Health health;
        public SpriteRenderer spriteRenderer;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        internal Animator animator;
        readonly CyberHoggModel model = Simulation.GetModel<CyberHoggModel>();

        public GameObject projectilePrefab;
        Vector2 lookDirection = new Vector2(1, 0);

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<CyberStopJump>().cyber = this;
                }

                if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
                {
                    lookDirection.Set(move.x, move.y);
                    lookDirection.Normalize();
                }

                if (Input.GetKeyDown(KeyCode.Z)) Launch();
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<CyberJumped>().cyber = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<CyberLanded>().cyber = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        void Launch()
        {
            GameObject projectileObject = Instantiate(projectilePrefab, body.position, Quaternion.identity);

            Projectile projectile = projectileObject.AddComponent<Projectile>();
            projectile.Launch(lookDirection, 600);

            animator.SetTrigger("shooting");
            audioSource.PlayOneShot(shootingAudio);
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}