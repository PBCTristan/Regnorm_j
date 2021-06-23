using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool m_FacingRight = true;

    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;
    private float xMovement;
    public static PlayerMovement instance;

    //trop de variables ici mdr
    public bool inventory = false;
    public GameObject inv;


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
        if (inventory)
        {
            if (Input.GetButtonDown("OpenInv"))
            {
                inventory = false;
                inv.SetActive(false);
            }
            else
            {
                if (Input.GetButtonDown("Left"))
                {
                    if (this.gameObject.transform.GetComponent<Weapon>().weaponsindex > 0)
                    {
                        this.gameObject.transform.GetComponent<Weapon>().weaponsindex--;
                        inv.transform.GetChild(1).position += new Vector3(-1, 0, 0);
                    }
                    else
                    {
                        this.gameObject.transform.GetComponent<Weapon>().weaponsindex = this.gameObject.transform.GetComponent<Weapon>().weapons.Count - 1;
                        inv.transform.GetChild(1).position += new Vector3(this.gameObject.transform.GetComponent<Weapon>().weapons.Count - 1, 0, 0);
                    }
                }

                if (Input.GetButtonDown("Right"))
                {
                    if (this.gameObject.transform.GetComponent<Weapon>().weaponsindex == this.gameObject.transform.GetComponent<Weapon>().weapons.Count - 1)
                    {
                        this.gameObject.transform.GetComponent<Weapon>().weaponsindex = 0;
                        inv.transform.GetChild(1).position += new Vector3(1 - this.gameObject.transform.GetComponent<Weapon>().weapons.Count, 0, 0);

                    }
                    else
                    {
                        this.gameObject.transform.GetComponent<Weapon>().weaponsindex++;
                        inv.transform.GetChild(1).position += new Vector3(1, 0, 0);
                    }
                }
            }
        }
        else
        {

            if (Input.GetButtonDown("OpenInv"))
            {
                inventory = true;
                inv.SetActive(true);
            }
            isGrounded = Physics2D.OverlapCircle(grounded.position, groundedRadius, collisionLayers);
            xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                isJumping = true;
            }

            if (Input.GetButtonDown("bigJump") && isGrounded)
            {
                bigJump = true;
            }

            Flip(rigidBody.velocity.x);
        }
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
            if (_velocity > 0.1f && !m_FacingRight)
            {
                //spriteRenderer.flipX = false;
                m_FacingRight = true;
                transform.Rotate(0f, 180f,0f);
            }
            else if (_velocity < -0.1f && m_FacingRight)
            {
                m_FacingRight = false;
                transform.Rotate(0f, 180f,0f);
                //transform.Rotate(0f, 0f,0f);
            }
        }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(grounded.position, groundedRadius);
    }
}
