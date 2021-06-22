using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        radius = 0.4f;
    }

    private void Update()
    {
        isColliding = Physics2D.OverlapCircle(hitbox.position, radius, whatIsSolid);

        if (isColliding)
        {
            Instantiate(bullethb, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        /*RaycastHit2D HitInfo2 = Physics2D.Raycast(transform.position, transform.up,distance, whatIsSolid);
        if (HitInfo2.collider != null)
        {
            if (HitInfo2.collider.CompareTag("DestructibleTerrain"))
            {
                Destroy(gameObject);
            }
        }*/
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("open");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(70);
        }
        Destroy(gameObject);
    }*/
}
