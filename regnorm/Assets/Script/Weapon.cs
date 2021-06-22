using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public List<GameObject> Prefabs;
    public List<int> weapons;
    public int weaponsindex;

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
}
