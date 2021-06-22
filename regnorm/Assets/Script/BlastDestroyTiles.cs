using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class BlastDestroyTiles : MonoBehaviour
{
    public Animator _animator;
    [SerializeField] private int timer;
    [SerializeField] private Tilemap tilemap;
    private Vector3[] circleVects = {
         new Vector3(-2, 0, 0), new Vector3(-1, -1, 0), new Vector3(-1, 0, 0), new Vector3(-1, 1, 0), new Vector3(0, -2, 0), new Vector3(0, -1, 0), new Vector3(0, 0, 0), 
         new Vector3(0, 1, 0), new Vector3(0, 2, 0), new Vector3(1, -1, 0), new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(2, 0, 0)
    };
    public ContactPoint2D[] contacts;
    
    void Start()
    {
        _animator.SetBool("boum",true);
        new WaitForSeconds(1);
        tilemap = GameObject.Find("Sol map").GetComponent<Tilemap>();
        timer = 0;
        for(int i = 0; i < circleVects.Length; ++i)
        {
            tilemap.SetTile(tilemap.WorldToCell(gameObject.transform.position + circleVects[i]), null);
        }
    }

    void Update()
    {
        if (timer >= 50)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(70);
            GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().PlayerScores[GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().playerturn] += 70;
        }
    }
}
