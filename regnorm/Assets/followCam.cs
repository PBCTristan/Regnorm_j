using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public Transform GameManager;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameManager.GetComponent<PlayRoundInstantiate>().Players[GameManager.GetComponent<PlayRoundInstantiate>().playerturn].position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameManager.GetComponent<PlayRoundInstantiate>().Players[GameManager.GetComponent<PlayRoundInstantiate>().playerturn].position + offset;
    }
}
