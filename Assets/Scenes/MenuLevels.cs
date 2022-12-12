using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevels : MonoBehaviour
{
    public void PlayLevel_1()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayLevel_2()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayLevel_3()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayLevel_4()
    {
        SceneManager.LoadScene(5);
    }
    public void PlayMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
