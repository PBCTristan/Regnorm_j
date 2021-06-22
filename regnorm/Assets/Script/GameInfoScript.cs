using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoScript : MonoBehaviour
{
    public int[] colors = {0, 0, 0, 0};
    public bool[] isAI = { false, false, false, false };

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
