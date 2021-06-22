using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject secondMenu;
    public GameObject settingsMenu;

    public void Start()
    {
        Screen.fullScreen = true;
    }
    public void PlayButton()
    {
        mainMenu.SetActive(false);
        secondMenu.SetActive(true);
    }
    public void SoloButton()
    {
        SceneManager.LoadScene("Assets/Scenes/Player Vs IA.unity");
    }

    public void MultiButton()
    {
        SceneManager.LoadScene("Assets/Scenes/Scene palette samuelle.unity");
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
    }

    public void Quit()
    {
        Application.Quit();
    }
}
