using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScore : MonoBehaviour
{
    public int playerindex;
    public Text text;

    void Update()
    {
        text.text = GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().PlayerScores[playerindex].ToString();
    }
}