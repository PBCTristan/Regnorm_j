using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public Transform pos;
    public int weapon;
    public Transform Player;

    void Start()
    {
        Debug.Log("chestplacing");
        pos.position = GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().spawnpoints[Random.Range(0, 3)].position - new Vector3(0, 1.14f, 0);
        weapon = Random.Range(0, 3);
    }

    void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            Player = GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().Players[GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().playerturn];
            if (Vector3.Distance(Player.GetChild(0).position, pos.position) < 1.2f)
            {
                TakeItem();
            }
        }
    }

    void TakeItem()
    {
        List<int> w = Player.GetChild(0).GetComponent<Weapon>().weapons;
        if (!w.Contains(weapon))
        {
            w.Add(weapon);
            Destroy(this.gameObject);
        }
    }
}
