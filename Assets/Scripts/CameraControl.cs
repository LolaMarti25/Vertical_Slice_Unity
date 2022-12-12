using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{

    public static CinemachineVirtualCamera ActiveCamera = null;
    public CinemachineFreeLook FreeLook;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        FreeLook.m_XAxis.m_MaxSpeed = 0;
        FreeLook.m_YAxis.m_MaxSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            FreeLook.m_XAxis.m_MaxSpeed = 300;
            FreeLook.m_YAxis.m_MaxSpeed = 2;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            FreeLook.m_XAxis.m_MaxSpeed = 0;
            FreeLook.m_YAxis.m_MaxSpeed = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
