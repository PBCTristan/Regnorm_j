using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roquetteBehaviour : MonoBehaviour
{
    [SerializeField] private int timer;
    public Transform blast;
    public Animator animator;
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
            animator.SetBool("Explode", true);
            Explode();
        }

        void Explode()
        {
            Instantiate(blast, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
