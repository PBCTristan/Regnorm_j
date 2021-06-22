using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == true)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        PlayerMovement.instance.enabled = true;
    }

    public void LoadMainMenu()
    {
        //DontDestroyOnLoad.instance.RemoveFromDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
        //pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

}
