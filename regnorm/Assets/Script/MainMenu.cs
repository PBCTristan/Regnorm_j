using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject secondMenu;
    public GameObject settingsMenu;

    public Text modtext;
    public Text maptext;

    public bool multi = false;
    public bool ice = false;

    public GameObject Solomenu;
    public GameObject Multimenu;

    public void Start()
    {
        Screen.fullScreen = true;
    }

    public void PlayButton()
    {
        mainMenu.SetActive(false);
        secondMenu.SetActive(true);
        Solomenu.SetActive(true);
    }
    public void ModButton()
    {
        if (multi)
        {
            modtext.text = "Solo";
            multi = false;
            Multimenu.SetActive(false);
            Solomenu.SetActive(true);
        }
        else
        {
            modtext.text = "Multijoueur";
            multi = true;
            Solomenu.SetActive(false);
            Multimenu.SetActive(true);
        }
    }

    public void MapButton()
    {
        if (ice)
        {
            maptext.text = "Grass";
            ice = false;
        }
        else
        {
            maptext.text = "Ice";
            ice = true;
        }
    }

    public void StartButton()
    {
        if (multi)
        {
            SceneManager.LoadScene("Assets/Scenes/Scene palette samuelle.unity");
        }
        else
        {
            SceneManager.LoadScene("Assets/Scenes/Player Vs IA.unity");
        }
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
        secondMenu.SetActive(false);
        mainMenu.SetActive(true);
        Solomenu.SetActive(false);
        Multimenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
