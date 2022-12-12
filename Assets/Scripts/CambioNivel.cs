using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    public GameObject cambioNivelUI;

    public void EndMinigame()
    {
        cambioNivelUI.SetActive(true);

    }

    public void CambiodeNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
