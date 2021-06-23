using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sabreBehiviour : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 30;
    public float distance;
    [SerializeField] private bool isColliding;
    public Rigidbody2D rb;
    public Transform bullethb;
    private float radius;
    private int timer;

    public LayerMask whatIsSolid;

    void Start()
    {
        timer = 0;
        rb.velocity = Vector2.zero;
        radius = 0.5f;
    }

    private void Update()
    {
        timer++;
        isColliding = Physics2D.OverlapCircle(this.gameObject.transform.position, radius, whatIsSolid); //Physics2D.OverlapCircle(hitbox.position, radius, whatIsSolid);

        if (isColliding)
        {
            Instantiate(bullethb, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (timer > 100)
        {
            Destroy(gameObject);
        }
    }
}
