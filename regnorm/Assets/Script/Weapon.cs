using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public List<GameObject> Prefabs;
    public List<int> weapons;
    public int weaponsindex;
    public int bombs;
    public List<Sprite> sprites;

    public Transform inv;

    private void Start()
    {
        weapons = new List<int>();
        weapons.Add(0);
        Debug.Log("crreeeee");
        weaponsindex = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(Prefabs[weapons[weaponsindex]], firePoint.position, firePoint.rotation);
    }

    public void Addweapon(int n)
    {
        weapons.Add(n);
        Debug.Log("fef");
        inv.GetChild(0).GetChild(weapons.Count - 1).GetComponent<Image>().sprite = sprites[n];
    }

    public void Addbombs(int n)
    {
        bombs += weaponsindex;
    }
}
