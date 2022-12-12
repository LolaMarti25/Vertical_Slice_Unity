using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject camerarock;
    public GameObject cameramontage;
    int cameraactual = 1;

    // Start is called before the first frame update
    void Start()
    {

        cameraPositionChange(cameraactual);
    }

    // Update is called once per frame
    void Update()
    {
        switchCamera();
    }

    void switchCamera()
    {
        //if (EndMinigame())
        //{
        //    cameraChangeCounter();
        //}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            cameraChangeCounter();
        }
    }

    public void cameraChangeCounter()
    {
        //int cameraPositionCounter = (0);
        cameraactual++;
        if (cameraactual > 1)
        {
            cameraactual = 0;
        }
        cameraPositionChange(cameraactual);
    }

    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //PlayerPrefs.SetInt("CameraPosition", camPosition);

        if (camPosition == 1)
        {
            camerarock.SetActive(true);
            cameramontage.SetActive(false);
        }

        if (camPosition == 0)
        {
            camerarock.SetActive(false);
            cameramontage.SetActive(true);
        }
    }
}
