using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseManuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseManuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseManuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MenuLevels()
    {
        SceneManager.LoadScene(1);
        GameIsPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
