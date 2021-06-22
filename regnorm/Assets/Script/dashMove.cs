using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private KeyCode lastKeyCode;
    private float doubleTapTime;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (doubleTapTime>Time.time&& lastKeyCode == KeyCode.LeftArrow)
                {
                    direction = 1;
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.LeftArrow;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (doubleTapTime>Time.time &&lastKeyCode == KeyCode.RightArrow)
                {
                    direction = 2;
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.RightArrow;
            }
        }
        else
        {
            if (dashTime<=0)
            {
                direction = 0;
                dashTime = startDashTime;
                rigidbody.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction==1)
                {
                    rigidbody.velocity = Vector2.left *dashSpeed;
                }
                else if (direction==2)
                {
                    rigidbody.velocity = Vector2.right *dashSpeed;
                }
            }
        }
    }
}
