using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoScript : MonoBehaviour
{
    public bool[] isAI = { true, true, true, true };

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
