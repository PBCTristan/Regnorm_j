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

    public void LeftButton()
    {
        if (gameinfo.GetComponent<GameInfoScript>().colors[i] > 0)
        {
            gameinfo.GetComponent<GameInfoScript>().colors[i]--;
        }
        else
        {
            gameinfo.GetComponent<GameInfoScript>().colors[i] = sprites.Count - 1;
        }
        charimage.sprite = sprites[gameinfo.GetComponent<GameInfoScript>().colors[i]];
    }

    public void RightButton()
    {
        gameinfo.GetComponent<GameInfoScript>().colors[i] = (gameinfo.GetComponent<GameInfoScript>().colors[i] + 1) % (sprites.Count);
        charimage.sprite = sprites[gameinfo.GetComponent<GameInfoScript>().colors[i]];
    }

    public void PlayerButton()
    {
        if (gameinfo.GetComponent<GameInfoScript>().isAI[i])
        {
            gameinfo.GetComponent<GameInfoScript>().isAI[i] = false;
            charimage.sprite = sprites[gameinfo.GetComponent<GameInfoScript>().colors[i]];
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
