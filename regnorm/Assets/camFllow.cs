using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class camFllow : MonoBehaviour
{
    public Transform GameManager;
    public Vector3 offset;
    /*void Start()
    {
        transform.position = GameManager.GetComponent<PlayRoundInstantiate>().Players[GameManager.GetComponent<PlayRoundInstantiate>().playerturn].position + offset;
    }

    // Update is called once per frame
    public void moche(Transform transform)
    {
        transform.position = transform.position + offset;
    }*/
    void Update()
    {
        transform.position = GameManager.GetComponent<PlayRoundInstantiate>().Players[GameManager.GetComponent<PlayRoundInstantiate>().playerturn].GetChild(0).position + offset;
    }
}
