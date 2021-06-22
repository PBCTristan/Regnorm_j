using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public Transform obj;

    void Update()
    {
        Vector3 newpos = new Vector3(obj.transform.position.x - transform.position.x, obj.transform.position.y - transform.position.y + 2f, obj.transform.position.z - transform.position.z);
        transform.Translate(newpos);
    }
}
