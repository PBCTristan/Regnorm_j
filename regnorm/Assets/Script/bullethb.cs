using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullethb : MonoBehaviour
{
    [SerializeField] private int timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        if (timer > 50)
        {
            Destroy(gameObject);
        }
        else
        {
            timer++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(15);
            GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().PlayerScores[GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().playerturn] += 15;
        }
    }
}
