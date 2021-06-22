using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool isJumping = false;
    public bool bigJump = false;
    public bool isDashing = false;
    public bool isGrounded;
    public Transform grounded;
    public float groundedRadius;
    public LayerMask collisionLayers;
    public float jumpForce;
    //dash
    public float dashDistance = 15f;
    private float doubleTapTime;
    private KeyCode lastKeyCode;
    
    //animator
    public Animator animator;

    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;
    private float xMovement;
    public static PlayerMovement instance;


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(grounded.position, groundedRadius, collisionLayers);
        xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("bigJump") &&isGrounded)
        {
            bigJump = true;
        }

        /*if (Input.GetKeyDown(KeyCode.C) && !isGrounded && xMovement != 0)
        {
            isDashing = true;
            CurrentDashTimer = StartDashTimer;
            rigidBody.velocity = Vector2.zero;
            DashDirection = (int) xMovement;
        }

        if (isDashing)
        {
            rigidBody.velocity = transform.right * DashDirection * DashForce;
            CurrentDashTimer -= Time.deltaTime;
            if (CurrentDashTimer<=0)
            {
                isDashing = false;
            }
        }*/
        Flip(rigidBody.velocity.x);
    }

    void MovePlayer(float _xMovement)
    {
        Vector3 targetVelocity = new Vector2(_xMovement, rigidBody.velocity.y);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, .05f);
        if (isJumping)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }

        if (bigJump)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce*2));
            bigJump = false;
        }
        float caracterVelocity = Math.Abs(rigidBody.velocity.x);
        animator.SetFloat("Speed", caracterVelocity);
    }

    private void FixedUpdate()
    {
        MovePlayer(xMovement);
        float caracterVelocity = Math.Abs(rigidBody.velocity.x);
        animator.SetFloat("Speed", caracterVelocity);
        animator.SetBool("isJumpingAnim", !isGrounded);
    }

    void Flip (float _velocity)
    {
        if (_velocity > 0.1f)
            spriteRenderer.flipX = false;
        if (_velocity < -0.1f)
            spriteRenderer.flipX = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(grounded.position, groundedRadius);
    }
}
