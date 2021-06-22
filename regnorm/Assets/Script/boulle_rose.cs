using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulle_rose : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 30;
    public float distance;
    [SerializeField] private bool isColliding;
    public Transform hitbox;
    public Rigidbody2D rb;
    public Transform bullethb;
    private float radius;

    public LayerMask whatIsSolid;

    void Start()
    {
        rb.velocity = transform.right * speed;
        radius = 0.6f;
    }

    private void Update()
    {
        isColliding = Physics2D.OverlapCircle(hitbox.position, radius, whatIsSolid);

        if (isColliding)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
