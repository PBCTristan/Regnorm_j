using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject gameinfo;
    public List<Sprite> sprites;
    public Image charimage;
    public Text Playertext;

    public int i;

    public void PlayerButton()
    {
        if (gameinfo.GetComponent<GameInfoScript>().isAI[i])
        {
            gameinfo.GetComponent<GameInfoScript>().isAI[i] = false;
            charimage.sprite = sprites[1];
            Playertext.text = "Player";
        }
        else
        {
            gameinfo.GetComponent<GameInfoScript>().isAI[i] = true;
            charimage.sprite = sprites[0];
            Playertext.text = "CPU";
        }
    }
}
