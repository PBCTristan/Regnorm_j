using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] private int timer;
    public Transform blast;
    public Animator animator;
    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if (timer > 1000)
        {
            animator.SetBool("Explode",true);
            //new WaitForSeconds(1);
            Explode();
        }
        else
        {
            timer++;
        }
    }

    void Explode()
    {
        Instantiate(blast, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
